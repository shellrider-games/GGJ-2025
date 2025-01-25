using Unity.VisualScripting;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public string CurrentState { get; private set; } = "idle";

    public void Place()
    {
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
