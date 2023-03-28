using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAmbienceSFX : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.loop = true;

        source.Play();
    }

    void Update()
    {
        
    }
}
