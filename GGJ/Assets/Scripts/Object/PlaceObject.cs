using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private Collider theWorldPlane;
    
    private Vector2 mousePosition;
    public bool placeObject = true;
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnPlaceObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if(theWorldPlane.Raycast(ray, out RaycastHit hit,100f))
            {
                Vector3 hitPosition = hit.point;
                Vector3 placePosition = HelperFunctions.WorldPosToGrid(hitPosition);

                Quaternion desiredRotation = gameObject.GetComponent<PreviewObject>().GetRotationPreview();
                
                if (!IsMouseOverObject(placePosition))
                {
                    Instantiate(objectToPlace, placePosition, desiredRotation).SetActive(true);
                }
                else
                {
                    Debug.Log("Object already exists");
                }
            }
        }
    }
    
    private bool IsMouseOverObject(Vector3 placePosition)
    {
        Collider[] colliders = Physics.OverlapSphere(placePosition, 0.1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("PlacedObject"))
            {
                return true;
            }
        }
        return false;
    }
}
