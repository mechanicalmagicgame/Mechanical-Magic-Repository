using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    //Static Add Writer to call in other classes/ scripts
    public static TextWriterSingle AddWriter_Static(Text uiText, string textToWrite, float timePerChar, bool invisibleChars, bool removeWriterBeforeAdd)
    {
        if (removeWriterBeforeAdd)
        {
            instance.RemoveWriter(uiText);
        }
        return instance.AddWriter(uiText, textToWrite, timePerChar, invisibleChars);
    }

    //Make new Writers
    private TextWriterSingle AddWriter(Text uiText, string textToWrite, float timePerChar, bool invisibleChars)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerChar, invisibleChars);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    //Static Remove writer to call in other classes/scripts
    public static void RemoveWriter_Static(Text uiText)
    {
        instance.RemoveWriter(uiText);
    }

    //Remove unnecessary Writers
    private void RemoveWriter(Text uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUIText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();

            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    //Represents a single instance of the text writer
    public class TextWriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int charIndex;
        private float timer;
        private float timePerChar;
        private bool invisibleChars;

        //Construvtor
        public TextWriterSingle(Text uiText, string textToWrite, float timePerChar, bool invisibleChars)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerChar = timePerChar;
            this.invisibleChars = invisibleChars;
            charIndex = 0;
        }

        //Returns true when complete
        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Display next char
                timer += timePerChar;
                charIndex++;

                string text = textToWrite.Substring(0, charIndex);
                if (invisibleChars)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(charIndex) + "</color>";
                }

                uiText.text = text;

                if (charIndex >= textToWrite.Length)
                {
                    //End of sentence
                    uiText = null;
                    return true;
                }
            }
            return false;
        }

        //returns reference to uiText for Remove Writer
        public Text GetUIText()
        {
            return uiText;
        }

        //Returns true if text is being written
        public bool IsActive()
        {
            return charIndex < textToWrite.Length;
        }

        //skip/speedup dialog writing
        public void SkipWriting()
        {
            //Commented code for outputing the entire dialog at once
            /*
            uiText.text = textToWrite;
            charIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(uiText);
            */

            timePerChar /= 10;
        }
    }
}
