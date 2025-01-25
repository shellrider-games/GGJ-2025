using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PreviewObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToPreview;
    [SerializeField] private Collider theWorldPlane;

    private GameObject _previewObject;
    private void Start()
    {
        _previewObject = Instantiate(objectToPreview, Vector3.zero, Quaternion.identity);
        _previewObject.SetActive(true);
    }

    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = context.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (theWorldPlane.Raycast(ray, out RaycastHit hit, 100f))
        {
            _previewObject.transform.position = HelperFunctions.WorldPosToGrid(hit.point);
        }
    }
}
