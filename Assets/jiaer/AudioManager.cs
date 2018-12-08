using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager instance;
    public AudioClip[] Music;
    public AudioClip[] Sound;
    public GameObject MusicManager;
    public GameObject SoundManager;
	// Use this for initialization
	void Start () {
        instance = this;
	}

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void PlayMusic(int ID)
    {
        MusicManager.GetComponent<AudioSource>().clip = Music[ID];
        MusicManager.GetComponent<AudioSource>().Play();
    }

    public void PlaySound(int ID)
    {
        SoundManager.GetComponent<AudioSource>().clip = Sound[ID];
        SoundManager.GetComponent<AudioSource>().Play();
    }
	

}
