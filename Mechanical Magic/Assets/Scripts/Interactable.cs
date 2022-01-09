using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRange;
    private bool isDialogActive;
    private DialogueManager dialogueManager;

    // Update is called once per frame
    void Update()
    {
        isDialogActive = FindObjectOfType<DialogueManager>().isDialogueActive;
        if ((Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange) && Input.GetKeyDown(KeyCode.Z) && !isDialogActive)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
