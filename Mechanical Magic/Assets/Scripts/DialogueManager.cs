using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameTextBox;
    public Text dialogueTextBox;

    private Queue<string> sentences;
    private bool isDialogueActive = false;

    public Animator animator;

    public float timePerChar;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        //Next/ Continue dialoogue trigger
        if (Input.GetKeyDown(KeyCode.X) && (isDialogueActive))
        {
            DisplayNextSentence();
        }


        if(dialogueTextBox != null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer += timePerChar;
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting Conversation With " + dialogue.name);

        nameTextBox.text = dialogue.name;

        isDialogueActive = true;

        animator.SetBool("IsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //Debug.Log(sentence);
        dialogueTextBox.text = sentence;
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        //Debug.Log("End of Conversation!");
        animator.SetBool("IsOpen", false);
    }

    public void Writer(string sentence, float timePerChar)
    {
        
    }
}
