using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectPlant : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    [Range(0f, 10f)] public int value=1;
    
    private PlayerInput _playerInput;
    private InputAction _mouseMoveAction;
    private InputAction _clickObjectAction;
    private Statemanager _statemanager;
    private Vector2 _mousePosition;
    private MoneyManager _moneyManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
        _statemanager = FindObjectOfType<Statemanager>();   
        
        _playerInput = FindObjectOfType<PlayerInput>();
        _mouseMoveAction = _playerInput.actions["MousePosition"];
        _clickObjectAction = _playerInput.actions["ClickOnObject"];
        _mouseMoveAction.performed += OnMouseMovement;
        _clickObjectAction.performed += OnClickOnObject;
    }

    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        _mousePosition = context.ReadValue<Vector2>();
    }
    
    public void OnClickOnObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && _statemanager.CurrentState == "idle")
        {
            Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit,100f))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    _moneyManager.AddMoney(value);
                    Instantiate(parent).transform.position = parent.transform.position;
                    Destroy(parent);
                }
            }
        }
    }
}
