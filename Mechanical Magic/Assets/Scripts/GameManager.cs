using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isDialogActiveGM;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    //private void Update()
    //{
    //    Debug.Log(StateManager.GetState());
    //}

    public Transform player;
}
