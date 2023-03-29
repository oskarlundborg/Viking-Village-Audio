using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonAudioController : MonoBehaviour
{
    private double time;
    private float stepFilterTime;

    private AudioSource footstepSource;
    public AudioClip[] footstepStoneClips;
    public AudioClip[] footstepDirtClips;
    public AudioClip[] footstepGrassClips;
    public AudioClip[] footstepWoodClips;

    public string groundTerrain = "No ground";

    void Start()
    {
        footstepSource = gameObject.AddComponent<AudioSource>();
        time = AudioSettings.dspTime;
        stepFilterTime = 0.2f;
    }

    void Update()
    {

    }

    void CheckGroundType()
    {
        RaycastHit hitInfo;
        GameObject groundObject = null; 
        SurfaceColliderType act;

        if(Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.2f))
        {
            if(groundObject== null)
            {
                groundObject = hitInfo.collider.gameObject;
            }
            act = gameObject.GetComponent<SurfaceColliderType>();
            while(act == null && gameObject.GetComponentInParent<Transform>() != null)
            {
                groundObject = groundObject.GetComponentInParent<Transform>().gameObject;
                act = groundObject.GetComponentInParent<SurfaceColliderType>();
            }
            if(act != null)
            {
                groundTerrain = act.GetTerrainType();
            }
        }
    }

    public void PlayFootstepSound()
    {
        CheckGroundType();
        if (AudioSettings.dspTime < time + stepFilterTime)  { return; }
        if(groundTerrain == "Stone")
        {
            int random = Random.Range(1, footstepStoneClips.Length);
            AudioClip temp = footstepStoneClips[random];
            footstepSource.PlayOneShot(footstepStoneClips[random]);
            footstepStoneClips[random] = footstepStoneClips[0];
            footstepStoneClips[0] = temp;
            time = AudioSettings.dspTime;
        } else if( groundTerrain == "Grass")
        {
            int random = Random.Range(1, footstepGrassClips.Length);
            AudioClip temp = footstepGrassClips[random];
            footstepSource.PlayOneShot(footstepGrassClips[random]);
            footstepGrassClips[random] = footstepGrassClips[0];
            footstepGrassClips[0] = temp;
            time = AudioSettings.dspTime;
        }
        else if (groundTerrain == "Wood")
        {
            int random = Random.Range(1, footstepWoodClips.Length);
            AudioClip temp = footstepWoodClips[random];
            footstepSource.PlayOneShot(footstepWoodClips[random]);
            footstepWoodClips[random] = footstepWoodClips[0];
            footstepWoodClips[0] = temp;
            time = AudioSettings.dspTime;
        } 
        else if (groundTerrain == "Dirt")
        {
            int random = Random.Range(1, footstepDirtClips.Length);
            AudioClip temp = footstepDirtClips[random];
            footstepSource.PlayOneShot(footstepDirtClips[random]);
            footstepDirtClips[random] = footstepDirtClips[0];
            footstepDirtClips[0] = temp;
            time = AudioSettings.dspTime;
        }
    }
}
