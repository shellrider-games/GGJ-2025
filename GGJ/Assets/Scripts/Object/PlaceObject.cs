using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private Collider theWorldPlane;
    private Vector2 mousePosition;
    private Statemanager _statemanager;
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        _statemanager = GetComponent<Statemanager>();
    }

    public void OnPlaceObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && _statemanager.CurrentState == "place")
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if(theWorldPlane.Raycast(ray, out RaycastHit hit,100f))
            {
                Vector3 hitPosition = hit.point;
                Vector3 placePosition = HelperFunctions.WorldPosToGrid(hitPosition);

                Quaternion desiredRotation = gameObject.GetComponent<PreviewObject>().GetRotationPreview();

                Instantiate(objectToPlace, placePosition, desiredRotation).SetActive(true);
            }
            
            _statemanager.Idle();
        }
    }
}
