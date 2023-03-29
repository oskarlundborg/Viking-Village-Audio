using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioController : MonoBehaviour
{
    private WindAmbienceSFX WindPlayer;
    private IndoorAmbienceSFX IndoorPlayer;
    void Start()
    {
        WindPlayer = GetComponentInChildren<WindAmbienceSFX>();
        IndoorPlayer = GetComponentInChildren<IndoorAmbienceSFX>();
    }

    public void SwapAmbience()
    {
        WindPlayer.FadeSound();
        IndoorPlayer.FadeSound();
    }

}
