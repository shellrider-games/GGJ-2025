using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuObject : MonoBehaviour
{
    public int value = 3;
    
    [SerializeField] private GameObject canvas;
    [SerializeField] private AudioClip selectPlanter;
    [SerializeField] private AudioClip sell;


    private Vector2 _mousePosition;
    private Statemanager _statemanager;
    private MoneyManager _moneyManager;

    private PlayerInput _playerInput;
    private InputAction _mouseMoveAction;
    private InputAction _clickObjectAction;
    private Outline _outline;
    private void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
        _statemanager = FindObjectOfType<Statemanager>();
        canvas.SetActive(false);
        
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
        
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
                if (hit.collider.gameObject == this.gameObject || hit.collider.gameObject == canvas)
                {
                    
                    AudioSource.PlayClipAtPoint(selectPlanter, transform.position);
                    
                    _outline.enabled = true;
                    canvas.SetActive(true);
                    return;
                }
                _outline.enabled = false;
                canvas.SetActive(false);
            }
        }
    }

    public void SellObject()
    {
        //sell sound
        AudioSource.PlayClipAtPoint(sell, transform.position);
        
        print("sell");
        _moneyManager.AddMoney(value);
        Destroy(this.gameObject);
    }
    
    private void OnDestroy()
    {
        if (_mouseMoveAction != null)
        {
            _mouseMoveAction.performed -= OnMouseMovement;
            _clickObjectAction.performed -= OnClickOnObject;
        }
    }
}
