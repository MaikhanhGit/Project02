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

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _touchPressAction = _playerInput.actions.FindAction("TouchPress");
        _touchPositionAction = _playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        _touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= TouchPressed;
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
}
