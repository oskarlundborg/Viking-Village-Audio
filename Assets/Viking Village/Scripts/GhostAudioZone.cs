using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudioZone : MonoBehaviour
{
    private GhostAudioController controller;
    private AudioSource source;
    private bool isPlaying = false;
    public float startingPlayTime = 5f;
    private float playTime;
    private float fadeTime = 3f;

    private void Start()
    {
        controller = GetComponentInParent<GhostAudioController>();
        source = GetComponent<AudioSource>();
        playTime = startingPlayTime;
    }

    private void Update()
    {
        if(isPlaying && playTime >= 0f)
        {
            playTime -= Time.deltaTime;
        } else if(playTime <= 0)
        {
            StartCoroutine(FadeOut());
        }
    }


    private void PlayGhostSounds()
    {
        if(isPlaying)
        {
            return;
        }
        source.clip = controller.GetClip();
        source.Play();
        isPlaying = true;
    }

    private IEnumerator FadeOut()
    {
        float timeElapsed = 0.0f;
        while(timeElapsed < fadeTime)
        {
            source.volume = Mathf.Lerp(1f, 0.01f, timeElapsed / fadeTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void ResetZone()
    {
        source.Stop();
        isPlaying = false;
        playTime = startingPlayTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(FadeOut());
            source.volume = 1f;
            PlayGhostSounds();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ResetZone();
        }
    }
}
