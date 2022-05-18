using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour{
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public AudioMixer audioMixer;
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void Back(){
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
