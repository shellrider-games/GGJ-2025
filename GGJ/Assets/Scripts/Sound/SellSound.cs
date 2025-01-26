using UnityEngine;

public class SellSound : MonoBehaviour
{
    
    [SerializeField] private AudioClip sellSound; 
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(sellSound, transform.position);
    }
}