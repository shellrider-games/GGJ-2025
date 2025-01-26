using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceObject : MonoBehaviour
{
    public int cost = 5;
    
    [SerializeField] private GameObject objectToPlace;
    [SerializeField] private GameObject humidifier;
    [SerializeField] private Collider theWorldPlane;
    [SerializeField] private MoneyManager moneyManager;
    
    private Vector2 mousePosition;
    private Statemanager _statemanager;
 
    private void Start()
    {
        _statemanager = GetComponent<Statemanager>();
    }

    
    public void OnMouseMovement(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnPlaceObject(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && (_statemanager.CurrentState == "place" || _statemanager.CurrentState == "humidifier"))
        {
            Place();
        }
    }

    public void Place()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if(theWorldPlane.Raycast(ray, out RaycastHit hit,100f))
        {
            Vector3 hitPosition = hit.point;
            Vector3 placePosition = HelperFunctions.WorldPosToGrid(hitPosition);

            Quaternion desiredRotation = gameObject.GetComponent<PreviewObject>().GetRotationPreview();
                
            if (!IsMouseOverObject(placePosition))
            {
                if (moneyManager.RemoveMoney(cost))
                {
                    if (moneyManager.RemoveMoney(cost))
                    {
                        if (_statemanager.CurrentState == "place")
                        {
                            Instantiate(objectToPlace, placePosition, desiredRotation).SetActive(true);
                        }
                        else if(_statemanager.CurrentState == "humidifier")
                        {
                            Instantiate(humidifier, placePosition, desiredRotation).SetActive(true);
                        }
                    }
                    _statemanager.Idle();
                }
                _statemanager.Idle();
            }
        }
    }

    public bool IsMouseOverObject(Vector3 placePosition)
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
