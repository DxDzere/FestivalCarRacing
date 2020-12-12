using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip mainTheme;
    public AudioClip menuTheme;
    public AudioClip mapaTheme;

    // Use this for initialization
    void Start ()
    {
        AudioManager.instance.PlayMusic(mainTheme, 2);
	}

    void Update()
    {
        
    }
}
