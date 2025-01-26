using Unity.VisualScripting;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClick; // List of audio clips to choose from

    public string CurrentState { get; private set; } = "idle";

    public void Place()
    {
        AudioSource.PlayClipAtPoint(buttonClick, transform.position);
        CurrentState = "place";
    }

    public void Edit()
    {
        CurrentState = "edit";
    }

    public void Idle()
    {
        CurrentState = "idle";
    }
}
