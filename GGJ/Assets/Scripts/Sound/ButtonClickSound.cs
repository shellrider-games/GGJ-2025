using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip buttonClick; // List of audio clips to choose from
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(buttonClick, transform.position);
    }
}
