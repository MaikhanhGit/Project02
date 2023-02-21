using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] GameObject _player;    
       
    private PlayerInput _playerInput;

    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;
    private InputAction _touchHoldAction;     
   
    public bool IsPressed { get; private set; } = false;    
    public bool IsHold { get; private set; } = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();        
        _touchPressAction = _playerInput?.actions.FindAction("TouchPress");
        _touchPositionAction = _playerInput?.actions.FindAction("TouchPosition");
        _touchHoldAction = _playerInput?.actions.FindAction("TouchHold");        
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

        float value = context.ReadValue<float>();
        /*
         Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
         position.z = _player.transform.position.z;
         _player.transform.position = position;
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
