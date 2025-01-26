using System.Collections.Generic;
using UnityEngine;

public class PlanterPlaceSound : MonoBehaviour
{
    [SerializeField] private AudioClip planterPlaceSound; 
    

    private void Start()
    {
        if (planterPlaceSound != null)
            AudioSource.PlayClipAtPoint(planterPlaceSound, transform.position);
    }
}
