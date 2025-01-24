using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private Collider theWorldPlane;
    private Vector2 mousePosition;
    
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
                Vector3 placePosition = new Vector3(Mathf.Round(hitPosition.x) + .5f, Mathf.Round(hitPosition.y), Mathf.Round(hitPosition.z) + .5f);
                Instantiate(objectToPlace, placePosition, Quaternion.identity).SetActive(true);
            }
        }
    }
    
}
