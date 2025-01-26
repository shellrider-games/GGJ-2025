using UnityEngine;

public class RemovePlanterSound : MonoBehaviour
{
    [SerializeField] private AudioClip planterRemoveSound; 
    

    private void Start()
    {
        if (planterRemoveSound != null)
            AudioSource.PlayClipAtPoint(planterRemoveSound, transform.position);
    }
}
