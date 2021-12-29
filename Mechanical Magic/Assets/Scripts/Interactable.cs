using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRange;

    // Update is called once per frame
    void Update()
    {
        if ((Vector2.Distance(gameObject.transform.position, GameManager.instance.player.position) < interactRange) && Input.GetKeyDown(KeyCode.Z))
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
