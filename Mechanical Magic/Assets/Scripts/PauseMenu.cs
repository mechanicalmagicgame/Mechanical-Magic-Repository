using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    private State prevState = State.Default;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(StateManager.GetState());
            if(isGamePaused)
            {
                Resume();
            }
            else if(StateManager.GetState() == State.Talking)
            {
                prevState = State.Talking;
                StateManager.SetState(State.Pause);
                Pause();
            }
            else {
                prevState = State.Default;
                StateManager.SetState(State.Pause);
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        StateManager.SetState(prevState);
        Time.timeScale = 1f;
        isGamePaused = false;
    }


    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void Title(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    public void Options(){

    }
}
