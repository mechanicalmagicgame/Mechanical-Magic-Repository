using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //Text Boxes
    public Text nameTextBox;
    public Text dialogueTextBox;

    //Variables for dialogs
    private Queue<string> sentences;    //Queue of sentences for dialogs
    private bool isDialogueActive = false;  //Check wether dialog is running or not

    public Animator animator;

    [SerializeField] private TextWriter textWriter;

    [Range(1,100)]public float timePerChar;


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
        //dialogueTextBox.text = sentence;
        textWriter.Writer(dialogueTextBox, sentence, timePerChar / 1000);
    }

    public void EndDialogue()
    {
        isDialogueActive = false;
        //Debug.Log("End of Conversation!");
        animator.SetBool("IsOpen", false);
    }
}
