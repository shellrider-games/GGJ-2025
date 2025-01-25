using UnityEngine;
using UnityEngine.InputSystem;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToDelete;
    [SerializeField] private Collider theWorldPlane;
    private Vector2 mousePosition;
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnDeleteObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit,100f))
            {
                objectToDelete = hit.collider.gameObject;
                if (objectToDelete.CompareTag("PlacedObject"))
                {
                    Destroy(objectToDelete);
                }
            }
        }
    }
}
