using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private Vector2 direction;
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        float rotatedX = direction.y * (Mathf.PI / 4) + direction.x * (Mathf.PI / 4);
        float rotatedY = direction.y * (Mathf.PI / 4) - direction.x * (Mathf.PI / 4);
        transform.position = new Vector3(
            transform.position.x + rotatedX * Time.deltaTime, 
            0, 
            transform.position.z + rotatedY * Time.deltaTime
        );
    }
}
