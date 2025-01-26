using System.Collections.Generic;
using UnityEngine;

public class PlacePipeSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> pipePlaceSounds; // List of audio clips to choose from
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(pipePlaceSounds[Random.Range(0, pipePlaceSounds.Count)], transform.position);
    }
}

