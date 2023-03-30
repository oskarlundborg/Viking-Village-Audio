using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!gameObject.GetComponentInParent<MusicController>().inTown){
                gameObject.GetComponentInParent<MusicController>().inTown = true;
                gameObject.GetComponentInParent<MusicController>().SwapToTownMusic();
            }
        }
    }
}
