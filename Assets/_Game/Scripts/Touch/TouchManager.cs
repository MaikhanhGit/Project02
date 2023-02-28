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
    private Camera _cameraMain;
    private Collider _hitObjectCollider;

    public bool IsPressed { get; private set; } = false;    
    public bool IsHold { get; private set; } = false;   

    public Ray TouchRay => _ray;
    public RaycastHit TouchRayHit => _hit;
    public Collider HitObjectCollider => _hitObjectCollider;
    public InputAction TouchPositionAction => _touchPositionAction;

    private void Awake()
    {
        _cameraMain = Camera.main;
        _playerInput = GetComponent<PlayerInput>();        
        _touchPressAction = _playerInput?.actions.FindAction(_touchPress);
        _touchPositionAction = _playerInput?.actions.FindAction(_touchPosition);
        _touchHoldAction = _playerInput?.actions.FindAction(_touchHold);     
        
    }

   
    private void OnEnable()
    {
        _touchPressAction.started += TouchPressed;        
        _touchPressAction.canceled += TouchReleased;
        //_touchPressAction.performed += TouchReleased;
        //_touchHoldAction.performed += TouchHold;               
    }

    private void OnDisable()
    {
        _touchPressAction.started -= TouchPressed;        
        _touchPressAction.canceled -= TouchPressed;
        //_touchPressAction.performed -= TouchReleased;
        //_touchHoldAction.performed -= TouchHold;
        IsPressed = false;
        
    }

   
    private void TouchPressed(InputAction.CallbackContext context)
    {
        if(context.started)
        {            
            IsPressed = true;
            Debug.Log(IsPressed);
            Vector3 position = _cameraMain.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
            // Ray ray = Camera.main.ScreenPointToRay(position);
            Ray ray = new Ray(position, _cameraMain.transform.forward);
            RaycastHit hit;
            Debug.DrawRay(position, _cameraMain.transform.forward * 100, Color.green, 1f);

            if (Physics.Raycast(ray, out hit))
            {
                _hitObjectCollider = hit.collider;
            }
        }

        if (context.canceled)
        {
            IsPressed = false;
        }
        /*
        if (Physics.Raycast(ray, out hit))
        {
            string name = hit.collider.gameObject.tag.ToString();
            Debug.Log(name);
        }"Touch
        */



        /* PLACE HOLDER: move game object on touch
        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
        position.y = _testObject.transform.position.y;
        _testObject.transform.position = position;
        */
    }
    
    private void TouchReleased(InputAction.CallbackContext context)
    {
        IsPressed = false;
        //IsHold = false;        
    }

    private void TouchHold(InputAction.CallbackContext context)
    {
        IsHold = true;
        
        /*
         _player.transform.localScale *= 2;
        */
    }
   
}
