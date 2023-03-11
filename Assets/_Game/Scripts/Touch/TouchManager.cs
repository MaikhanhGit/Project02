using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

[RequireComponent(typeof(PlayerInput))]
public class TouchManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _touchPositionAction;
    private InputAction _touchPressAction;
    GamePiece _gamePiece;

    private string _touchPress = "TouchPress";
    private string _touchPosition = ("TouchPosition");
    private bool _isPicked = false;

    private Ray _ray;
    private RaycastHit _hit;
    private Camera _cameraMain;
    private Collider _hitObjectCollider;


    public bool IsPressed { get; private set; } = false;

    public Ray TouchRay => _ray;
    public RaycastHit TouchRayHit => _hit;
    public Collider HitObjectCollider => _hitObjectCollider;
    public InputAction TouchPositionAction => _touchPositionAction;

    public event Action<Collider> TouchPressed = delegate { };
    public event Action TouchReleased = delegate { };
    public event Action ValidMove = delegate { };

    private void Awake()
    {        
        _cameraMain = Camera.main;
        _playerInput = GetComponent<PlayerInput>();        
        _touchPressAction = _playerInput.actions.FindAction(_touchPress);
        _touchPositionAction = _playerInput?.actions.FindAction(_touchPosition);
                
    }

    private void OnEnable()
    {
        //_touchPositionAction.performed += OnPressed;
        _touchPressAction.performed += OnPressed;                
    }

    private void OnDisable()
    {
        //_touchPositionAction.performed -= OnPressed;
        _touchPressAction.performed -= OnPressed;
    }

    private void OnPressed(InputAction.CallbackContext context)
    {        
        if (context.performed)
        {            
            Vector3 position = _cameraMain.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
            //Ray ray = Camera.main.ScreenPointToRay(position);
            Ray ray = new Ray(position, _cameraMain.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(position, _cameraMain.transform.forward * 100, Color.green, 1f);

            if (Physics.Raycast(ray, out hit))
            {                
                TouchPressed?.Invoke(hit.collider);               
            }
                
        } 
    }
      
}
