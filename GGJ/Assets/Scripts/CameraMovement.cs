using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private const float Degrees45 = (Mathf.PI / 4);
    private Vector2 keyboardDirection;
    private Vector2 mouseDirection;
    private bool useKeyboard = false;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        keyboardDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector2 direction = useKeyboard ? keyboardDirection.normalized : mouseDirection.normalized;
        float rotatedX = direction.y * Degrees45 + direction.x * Degrees45;
        float rotatedY = direction.y * Degrees45 - direction.x * Degrees45;
        transform.position = new Vector3(
            transform.position.x + rotatedX * Time.deltaTime, 
            0, 
            transform.position.z + rotatedY * Time.deltaTime
        );
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        
        useKeyboard = true;
        mouseDirection = Vector2.zero;
        
        if (mousePosition.x < 32)
        {
            useKeyboard = false;
            mouseDirection.x = -1;
        }

        if (mousePosition.x > Screen.width - 32)
        {
            useKeyboard = false;
            mouseDirection.x = 1;
        }

        if (mousePosition.y < 32)
        {
            useKeyboard = false;
            mouseDirection.y = -1;
        }
        
        if (mousePosition.y > Screen.height - 32)
        {
            useKeyboard = false;
            mouseDirection.y = 1;
        }
        
        Debug.Log(mousePosition);
    }
}
