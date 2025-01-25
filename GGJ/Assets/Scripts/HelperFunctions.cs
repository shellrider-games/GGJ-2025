using UnityEngine;

public static class HelperFunctions
{
    public static Vector3 WorldPosToGrid(Vector3 worldPos)
    {
        return new Vector3(Mathf.Round(worldPos.x) + .5f, Mathf.Round(worldPos.y), Mathf.Round(worldPos.z) + .5f);
    }
}
