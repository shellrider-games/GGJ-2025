using UnityEngine;
using UnityEngine.InputSystem;

public class PreviewObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPreview;
    [SerializeField] private Collider theWorldPlane;
    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        
        
    }
}
