using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

    private AudioSource audioSource;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
	}
    
    public void PlayMusic(AudioMusic audioMusic)
    {
        audioSource.clip = audioMusic.soundToPlay;
        audioSource.Play();
    }
}
