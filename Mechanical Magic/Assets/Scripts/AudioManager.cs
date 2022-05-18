using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    
    private void Awake() {

        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
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
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

        if(s == null){
            Debug.LogWarning("Sound not found: " + name);
        }
    }

    public void Stop (string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();

        if(s == null){
            Debug.LogWarning("Sound not found: " + name);
        }
    }
}
