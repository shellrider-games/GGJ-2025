using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CollectPlant : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [SerializeField] private AudioClip sellSound;
    

    [Range(0f, 10f)] public int value=1;

    [SerializeField] private UnityEvent onCollect;

    public static event Action collectedPlant;
    
    private PlayerInput _playerInput;
    private InputAction _mouseMoveAction;
    private InputAction _clickObjectAction;
    private Statemanager _statemanager; 

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _statemanager = FindObjectOfType<Statemanager>();   
        _playerInput = FindObjectOfType<PlayerInput>();
        _clickObjectAction = _playerInput.actions["ClickOnObject"];
        _clickObjectAction.performed += OnClickOnObject;
    }

 
    
    public void OnClickOnObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && _statemanager.CurrentState == "idle")
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(Physics.Raycast(ray, out RaycastHit hit,100f))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    AudioSource.PlayClipAtPoint(sellSound, transform.position);
                    onCollect.Invoke();
                    collectedPlant?.Invoke();
                }
            }
        }
    }
}
