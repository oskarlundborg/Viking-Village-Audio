using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.GetComponentInParent<MusicController>().inTown)
            {
                gameObject.GetComponentInParent<MusicController>().inTown = false;
                gameObject.GetComponentInParent<MusicController>().SwapToFieldMusic();
            }
        }
    }
}
