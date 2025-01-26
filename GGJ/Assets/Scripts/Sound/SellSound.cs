using UnityEngine;

public class SellSound : MonoBehaviour
{
    
    [SerializeField] private AudioClip sellSound; 
    

    private void Start()
    {
        if (sellSound != null)
            AudioSource.PlayClipAtPoint(sellSound, transform.position);
    }
}