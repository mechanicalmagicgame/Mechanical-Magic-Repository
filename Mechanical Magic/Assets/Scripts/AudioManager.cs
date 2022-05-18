using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    private void Awake() {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    private void Start() {
        Play("SanLoro(Background)");
    }

    public void StartBackgroundMusic(){
        Play("SanLoro(Background)");
    }

    public void StopBackgroundMusic(){
        Stop("SanLoro(Background)");
    }

    public void Play (string name){
        Array.Find(sounds, sound => sound.name == name).source.Play();
    }

    public void Stop (string name){
        Array.Find(sounds, sound => sound.name == name).source.Stop();
    }
}
