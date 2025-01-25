using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasLookAtCameraObject : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    private Camera _mainCamera;
    private PlayerInput _playerInput;
    private InputAction moveAction;
    private InputAction mouseMoveAction;
    private void Start()
    {
        _mainCamera = Camera.main;
        
        _playerInput = FindObjectOfType<PlayerInput>();
        moveAction = _playerInput.actions["Move"];
        mouseMoveAction = _playerInput.actions["MousePosition"];
        moveAction.performed += LookAtCamera;
        mouseMoveAction.performed += LookAtCamera;
        
        print("test");
    }

    public void LookAtCamera(InputAction.CallbackContext context)
    {
        canvas.transform.LookAt(canvas.transform.position + _mainCamera.transform.rotation * Vector3.forward, _mainCamera.transform.rotation * Vector3.up);
    }
    
    private void OnDestroy()
    {
        if (moveAction != null)
        {
            moveAction.performed -= LookAtCamera;
            mouseMoveAction.performed -= LookAtCamera;
        }
    }
}