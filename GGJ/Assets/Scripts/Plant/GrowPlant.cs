using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class GrowPlant : MonoBehaviour
{
    [SerializeField] private List<AudioClip> plantSounds;
    [SerializeField] private GameObject startState;
    [SerializeField] private GameObject endState;
    [Range(0f, 50f)] public float growthTime;
    [Range(0f, 20f)] public float randomizeGrowthTime=3f;

    private Coroutine growingCoroutine;
    
    
    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        StopAllCoroutines();
        startState.SetActive(true);
        endState.SetActive(false);
        growingCoroutine = StartCoroutine(StartGrowPlant());
    }

    private IEnumerator StartGrowPlant()
    {
        yield return new WaitForSeconds(growthTime+Random.Range(0, randomizeGrowthTime));
        
        AudioSource.PlayClipAtPoint(plantSounds[Random.Range(0, plantSounds.Count)], transform.position);
        
        startState.SetActive(false);
        endState.SetActive(true);
    }
   
}