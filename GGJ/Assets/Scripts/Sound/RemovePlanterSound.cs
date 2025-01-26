using UnityEngine;

public class RemovePlanterSound : MonoBehaviour
{
    [SerializeField] private AudioClip planterRemoveSound; 
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(planterRemoveSound, transform.position);
    }
}
