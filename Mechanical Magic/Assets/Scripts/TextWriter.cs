using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string textToWrite;
    private int charIndex;
    private float timer;
    private float timePerChar;

    public void Writer(Text uiText, string textToWrite, float timePerChar)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerChar = timePerChar;
        charIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                //Display next char
                timer += timePerChar;
                charIndex++;
                uiText.text = textToWrite.Substring(0, charIndex);

                if (charIndex >= textToWrite.Length)
                {
                    //End of sentence
                    uiText = null;
                    return;
                }
            }
        }
    }
}
