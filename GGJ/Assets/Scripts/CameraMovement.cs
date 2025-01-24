using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private const float Degrees45 = (Mathf.PI / 4);
    private Vector2 direction;
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        float rotatedX = direction.y * Degrees45 + direction.x * Degrees45;
        float rotatedY = direction.y * Degrees45 - direction.x * Degrees45;
        transform.position = new Vector3(
            transform.position.x + rotatedX * Time.deltaTime, 
            0, 
            transform.position.z + rotatedY * Time.deltaTime
        );
    }
}
