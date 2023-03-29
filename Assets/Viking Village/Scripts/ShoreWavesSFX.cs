using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoreWavesSFX : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;


    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.loop = true;

        source.time = Random.Range(0.0f, clip.length);

        source.Play();
    }
}
