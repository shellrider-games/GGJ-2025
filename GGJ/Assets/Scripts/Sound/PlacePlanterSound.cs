using System.Collections.Generic;
using UnityEngine;

public class PlanterPlaceSound : MonoBehaviour
{
    [SerializeField] private AudioClip planterPlaceSound; 
    

    private void Start()
    {
        AudioSource.PlayClipAtPoint(planterPlaceSound, transform.position);
    }
}
