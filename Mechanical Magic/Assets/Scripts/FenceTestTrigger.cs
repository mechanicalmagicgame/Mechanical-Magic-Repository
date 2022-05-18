using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceTestTrigger : Interactable
{
    public override void Interact()
    {
        Debug.Log("You just Interacted with Fence!!");
        PlayVictoryAudio();
    }

    void PlayVictoryAudio(){

        FindObjectOfType<AudioManager>().StopBackgroundMusic();
        FindObjectOfType<AudioManager>().Play("Victory");
    }
}
