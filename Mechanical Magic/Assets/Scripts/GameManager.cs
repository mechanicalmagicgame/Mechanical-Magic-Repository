using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // [HideInInspector]public GameObject playerGameObject;
    public Transform player;

    public bool isDialogActiveGM;

    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
       if(player == null){
           player = FindObjectOfType<GameObject>().transform;
       }
    }
}
