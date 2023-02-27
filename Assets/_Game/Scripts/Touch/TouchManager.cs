using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{    
    private PlayerInput _playerInput;
    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;
    private InputAction _touchHoldAction;     

    private string _touchPress = "TouchPress";
    private string _touchPosition = ("TouchPosition");
    private string _touchHold = ("TouchHold");

    private Ray _ray;
    private RaycastHit _hit;

    public bool IsPressed { get; private set; } = false;    
    public bool IsHold { get; private set; } = false;

    public Ray TouchRay => _ray;
    public RaycastHit TouchRayHit => _hit;
    public InputAction TouchPositionAction => _touchPositionAction;

    private void Awake()
    {

        _playerInput = GetComponent<PlayerInput>();        
        _touchPressAction = _playerInput?.actions.FindAction(_touchPress);
        _touchPositionAction = _playerInput?.actions.FindAction(_touchPosition);
        _touchHoldAction = _playerInput?.actions.FindAction(_touchHold);        
    }

   
    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
        _touchPressAction.canceled += TouchReleased;
        _touchHoldAction.performed += TouchHold;               
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
        _touchPressAction.canceled -= TouchReleased;
        _touchHoldAction.performed -= TouchHold;
        IsPressed = false;
        IsHold = false;
    }

   
    private void TouchPressed(InputAction.CallbackContext context)
    {
        IsPressed = true;

        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;                 

        /* PLACE HOLDER: move game object on touch
        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
        position.y = _testObject.transform.position.y;
        _testObject.transform.position = position;
        */
    }
    
    private void TouchReleased(InputAction.CallbackContext context)
    {
        IsPressed = false;
        IsHold = false;        
    }

    private void TouchHold(InputAction.CallbackContext context)
    {
        IsHold = true;
        
        /*
         _player.transform.localScale *= 2;
        */
    }
   
}
