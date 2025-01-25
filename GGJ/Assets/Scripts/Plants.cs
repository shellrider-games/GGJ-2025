using System;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] private GameObject startState;
    [SerializeField] private GameObject endState;
    [Range(0, 20)] public float growthTime;
    
    private float timer = 0f;

    public void Start()
    {
        startState.SetActive(true);
        endState.SetActive(false);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= growthTime)
        {
            startState.SetActive(false);
            endState.SetActive(true);
        }
    }
}
