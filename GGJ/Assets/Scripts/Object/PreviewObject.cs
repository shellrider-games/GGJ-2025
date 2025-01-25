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
