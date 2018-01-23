using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static SoundManagerScript instance = null;

    public AudioSource audioSE;
    public AudioSource audioBGM;


    public AudioClip clipGameBGM;

    // Use this for initialization
    void Awake () {
		if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Init();
	}

    void Init()
    {
        audioSE = gameObject.AddComponent<AudioSource>();

        audioBGM = gameObject.AddComponent<AudioSource>();
        audioBGM.loop = true;

        
    }
	
    public void PlayBGM()
    {
        audioBGM.clip = clipGameBGM;
        audioBGM.Play();
    }
    public void PlaySE()
    {
        AudioClip clip = null;
        audioSE.PlayOneShot(clip);
    }

}
