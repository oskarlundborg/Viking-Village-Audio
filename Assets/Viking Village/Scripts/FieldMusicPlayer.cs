using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMusicPlayer : MonoBehaviour
{
    private AudioSource[] sources = new AudioSource[2];
    private int flip = 0;
    private double nextEventTime;
    public float volume = 1f;
    public float fadeTime = 3f;
    public AudioClip clip;

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].clip = clip;
            sources[i].volume = 0;
        }
        nextEventTime = AudioSettings.dspTime + 1.0f;
    }

    void Update()
    {
        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            sources[flip].PlayScheduled(nextEventTime);
            nextEventTime += clip.length - 1f;
            flip = 1 - flip;
        }
    }

    public void FadeInMusic()
    {
        StopCoroutine(FadeOut());
        StartCoroutine(FadeIn());
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < fadeTime)
        {
            foreach (AudioSource source in sources)
            {
                source.volume = Mathf.Lerp(volume, 0f, timeElapsed / fadeTime);
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < fadeTime)
        {
            foreach (AudioSource source in sources)
            {
                source.volume = Mathf.Lerp(0f, volume, timeElapsed / fadeTime);
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
