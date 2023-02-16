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

    private bool _hold = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions.FindAction("TouchPress");
        _touchPositionAction = _playerInput.actions.FindAction("TouchPosition");
        _touchHoldAction = _playerInput.actions.FindAction("TouchHold");
    }

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
        _touchHoldAction.performed += TouchHold;        
       
        
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
        _touchHoldAction.performed -= TouchHold;        

    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);        

        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
        position.z = _player.transform.position.z;
        _player.transform.position = position;

        Debug.Log(position);

    }

    private void TouchHold(InputAction.CallbackContext context)
    {        
        _player.transform.localScale *= 2;

    }
   
}
