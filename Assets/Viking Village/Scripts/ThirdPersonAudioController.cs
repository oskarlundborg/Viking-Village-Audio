using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonAudioController : MonoBehaviour
{
    private double time;
    private float stepFilterTime;

    private AudioSource footstepSource;
    private AudioSource jumpSource;
    public AudioClip[] footstepStoneClips;
    public AudioClip[] footstepDirtClips;
    public AudioClip[] footstepGrassClips;
    public AudioClip[] footstepWoodClips;
    public AudioClip[] jumpClips;
    public AudioClip[] landingStoneClips;
    public AudioClip[] landingWoodClips;
    public AudioClip[] landingDirtClips;

    public string groundTerrain = "No ground";

    void Start()
    {
        footstepSource = gameObject.AddComponent<AudioSource>();
        jumpSource = gameObject.AddComponent<AudioSource>();
        time = AudioSettings.dspTime;
        stepFilterTime = 0.2f;
    }

    public void PlayLandingSound()
    {
        CheckGroundType();
        if (groundTerrain == "Stone")
        {
            int random = Random.Range(1, landingStoneClips.Length);
            AudioClip temp = landingStoneClips[random];
            jumpSource.PlayOneShot(landingStoneClips[random]);
            landingStoneClips[random] = landingStoneClips[0];
            landingStoneClips[0] = temp;
        }
        else if (groundTerrain == "Wood")
        {
            int random = Random.Range(1, landingWoodClips.Length);
            AudioClip temp = landingWoodClips[random];
            jumpSource.PlayOneShot(landingWoodClips[random]);
            landingWoodClips[random] = landingWoodClips[0];
            landingWoodClips[0] = temp;
        }
        else if (groundTerrain == "Dirt")
        {
            int random = Random.Range(1, landingDirtClips.Length);
            AudioClip temp = landingDirtClips[random];
            jumpSource.PlayOneShot(landingDirtClips[random]);
            landingDirtClips[random] = landingDirtClips[0];
            landingDirtClips[0] = temp;
        }
    }

    public void PlayJumpSound()
    {
        int random = Random.Range(1, jumpClips.Length);
        AudioClip temp = jumpClips[random];
        jumpSource.PlayOneShot(jumpClips[random]);
        jumpClips[random] = jumpClips[0];
        jumpClips[0] = temp;
    }

    void CheckGroundType()
    {
        RaycastHit hitInfo;
        GameObject groundObject = null; 
        SurfaceColliderType act;

        if(Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.25f))
        {
            if(groundObject== null)
            {
                groundObject = hitInfo.collider.gameObject;
            }
            act = gameObject.GetComponent<SurfaceColliderType>();
            int maxCount = 0;
            while(act == null && gameObject.GetComponentInParent<Transform>() != null)
            {
                if(maxCount > 5)
                {
                    Debug.Log("Stopped the loop");
                    break;
                }
                maxCount++;
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
