using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAmbienceSFX : MonoBehaviour
{
    private AudioSource[] sources = new AudioSource[2];
    private int flip = 0;
    private double nextEventTime;
    public float volume = 1f;
    public AudioClip clip;
    
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].clip = clip;
            sources[i].volume = volume; 
        }
        nextEventTime = AudioSettings.dspTime + 1.0f;
    }

    void Update()
    {
        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            sources[flip].PlayScheduled(nextEventTime);
            nextEventTime += clip.length -1f;
            flip = 1 - flip;
        }
    }
}
