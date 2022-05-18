using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("Alleyway");
        StateManager.SetState(State.Default);
    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
