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
    [SerializeField] private GameObject humidifier;
    [Range(0f, 50f)] public float baseGrowthTime = 5f;
    [Range(0f, 20f)] public float randomizeGrowthTime = 10f;
    [Range(0f, 10f)] public float proximityThreshold = 3f;

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
        float distanceToHumidifier = Vector3.Distance(transform.position, humidifier.transform.position);
        Debug.Log("Planter pos:" + transform.position);
        Debug.Log("Humidifier pos:" + humidifier.transform.position);
        float growthTime = distanceToHumidifier <= proximityThreshold ? baseGrowthTime / 2 : baseGrowthTime;
        Debug.Log("Growth time:" + baseGrowthTime);
        yield return new WaitForSeconds(growthTime+Random.Range(0, randomizeGrowthTime));
        
        AudioSource.PlayClipAtPoint(plantSounds[Random.Range(0, plantSounds.Count)], transform.position);
        
        startState.SetActive(false);
        endState.SetActive(true);
    }
   
}