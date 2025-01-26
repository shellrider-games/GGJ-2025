using UnityEngine;

public class RemoveFish : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip pumpRemoveSound; // List of audio clips to choose from
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(pumpRemoveSound, transform.position);
    }
}
