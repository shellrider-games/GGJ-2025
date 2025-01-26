using System.Collections.Generic;
using UnityEngine;

public class FishPlaceSound : MonoBehaviour
{
    [SerializeField] private List<AudioClip> fishPlaceSounds; // List of audio clips to choose from
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(fishPlaceSounds[Random.Range(0, fishPlaceSounds.Count)], transform.position);
    }
}
