using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] private Material startState;
    [SerializeField] private Material endState;
    [Range(0, 20)] public float growingSpeed;

    public void Growing()
    {
        endState.SetColor("_Color", Color.red);
    }

}
