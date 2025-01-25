using System;
using UnityEngine;
using UnityEngine.InputSystem;


// How to use:
// Instanciate Script and give following params:
//  - ObjectToPreview: gameobject that represents the previewed object
//  - theWorldPlane: the worldPlane of the game.
// After Placing the Gameobject destory this Script.
public class PreviewObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPreview;
    [SerializeField] private Collider theWorldPlane;

    private GameObject _previewObject;
    private Statemanager _statemanager;
    private void Start()
    {
        _previewObject = Instantiate(objectToPreview, Vector3.zero, Quaternion.identity);
        _previewObject.SetActive(false);
        _statemanager = GetComponent<Statemanager>();
    }

    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        if (_statemanager.CurrentState != "place")
        {
            _previewObject.SetActive(false);
            return;
        }
        
        _previewObject.SetActive(true);
        Vector2 mousePosition = context.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (theWorldPlane.Raycast(ray, out RaycastHit hit, 100f))
        {
            _previewObject.transform.position = HelperFunctions.WorldPosToGrid(hit.point);
        }
    }

    public void OnRotateObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _previewObject.transform.Rotate(0, 90, 0);
        }
    }

    public Quaternion GetRotationPreview()
    {
        return _previewObject.transform.rotation;
    }
}
