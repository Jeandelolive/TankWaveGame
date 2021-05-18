using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMusic : MonoBehaviour
{

    private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            print("Play music");
            music.Play();
        }
    }
}
