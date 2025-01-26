using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] private List<AudioClip> plantSounds; // List of audio clips to choose from
    [SerializeField] private GameObject startState;
    [SerializeField] private GameObject endState;
    [Range(0, 20)] public float growthTime;

    private void Start()
    {
        startState.SetActive(true);
        endState.SetActive(false);

        // Start the growth coroutine
        StartCoroutine(GrowPlant());
    }

    private IEnumerator GrowPlant()
    {
        float timer = 0f;

        // Wait until the growth time is reached
        while (timer < growthTime)
        {
            timer += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Play a random sound from the list
        if (plantSounds != null && plantSounds.Count > 0)
            AudioSource.PlayClipAtPoint(plantSounds[UnityEngine.Random.Range(0, plantSounds.Count)], transform.position);

        // Switch states
        startState.SetActive(false);
        endState.SetActive(true);
    }
}