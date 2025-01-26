using UnityEngine;

public class PlacePump : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip pumpPlaceSound; // List of audio clips to choose from
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(pumpPlaceSound, transform.position);
    }
}
