using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip buttonClick; // List of audio clips to choose from
    

    private void Start()
    {
        if (buttonClick != null)
            AudioSource.PlayClipAtPoint(buttonClick, transform.position);
    }
}
