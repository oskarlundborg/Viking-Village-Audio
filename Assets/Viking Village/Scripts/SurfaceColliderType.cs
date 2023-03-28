using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceColliderType : MonoBehaviour
{
    public enum Mode { Stone, Grass, Dirt, Wood}

    public Mode terrainType;

    public string GetTerrainType()
    {
        string terrainString;

        switch (terrainType)
        {
            case Mode.Stone:
                terrainString = "Stone";
                break;
            case Mode.Grass:
                terrainString = "Grass";
                break;
            case Mode.Wood:
                terrainString = "Wood";
                break;
            case Mode.Dirt:
                terrainString = "Dirt";
                break;
            default:
                terrainString = string.Empty;
                break;
        }
        return terrainString;
    }
}
