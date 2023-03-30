using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudioController : MonoBehaviour
{
    private int creepynessLevel = 0;
    public AudioClip[] ghostClips;

    public AudioClip GetClip()
    {
        if(creepynessLevel < 10)
        {
            creepynessLevel++;
            Debug.Log(creepynessLevel);
            return ghostClips[creepynessLevel-1];
        }
        return GetRandomEndgameClip();
    }

    public AudioClip GetRandomEndgameClip()
    {
        int random = Random.Range(10, 13);
        Debug.Log("Random clip = " + random);
        AudioClip clipToReturn = ghostClips[random];
        ghostClips[random] = ghostClips[10];
        ghostClips[10] = clipToReturn;
        return clipToReturn;
    }
}
