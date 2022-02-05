using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Text Boxes
    public Text nameTextBox;
    public Text dialogueTextBox;
    public Image image;

    //Variables for dialogs
    private Queue<string> sentences;    //Queue of sentences for dialogs
    [HideInInspector]public bool isDialogueActive = false;  //Check wether the dialog is running or not


    //Animator reference for open/close animation
    public Animator animator;

    //Speed of text output
    [Range(1,100)]public float timePerChar;

    //Text Writer Instance for skip dialog
    private TextWriter.TextWriterSingle textWriterSingle;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X)) && isDialogueActive)
        {
            StateManager.SetState(State.Talking);
            if (textWriterSingle.IsActive() && textWriterSingle != null)
            {
                //Currently Writing
                textWriterSingle.SkipWriting();
            }
            else
            {
                //Next/ Continue dialoogue
                DisplayNextSentence();
            }
        } 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting Conversation With " + dialogue.name);
        // image.sprite = dialogue.sprite;
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
        //dialogueTextBox.text = sentence;
        textWriterSingle = TextWriter.AddWriter_Static(dialogueTextBox, sentence, timePerChar / 1000, true, true);
    }

    public void EndDialogue()
    {
        StateManager.ActiveState = State.Default;
        isDialogueActive = false;
        //Debug.Log("End of Conversation!");
        animator.SetBool("IsOpen", false);
    }
}
