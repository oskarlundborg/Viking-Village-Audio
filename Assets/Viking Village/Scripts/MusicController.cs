using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private FieldMusicPlayer fieldPlayer;
    private TownMusicPlayer townPlayer;
    public bool inTown = true;


    private void Start()
    {
        fieldPlayer = GetComponentInChildren<FieldMusicPlayer>();
        townPlayer = GetComponentInChildren<TownMusicPlayer>();
    }

    public void SwapToTownMusic()
    {
        Debug.Log("Swapping to town");
        fieldPlayer.FadeOutMusic();
        townPlayer.FadeInMusic();
    }

    public void SwapToFieldMusic()
    {
        Debug.Log("Swapping to field");
        fieldPlayer.FadeInMusic();
        townPlayer.FadeOutMusic();
    }
}
