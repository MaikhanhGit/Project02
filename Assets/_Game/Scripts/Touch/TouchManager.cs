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

    public event Action<Collider> TouchPressed = delegate {}; 

    private void Awake()
    {        
        _cameraMain = Camera.main;
        _playerInput = GetComponent<PlayerInput>();        
        _touchPressAction = _playerInput?.actions.FindAction(_touchPress);
        _touchPositionAction = _playerInput?.actions.FindAction(_touchPosition);      
        
    }

   
    private void OnEnable()
    {
        _touchPressAction.performed += OnPressed;                             
    }

    private void OnDisable()
    {
        _touchPressAction.performed -= OnPressed;       
        
    }

   
    private void OnPressed(InputAction.CallbackContext context)
    {        
            if (context.performed)
            {
            // IsPressed = true;            

                Vector3 position = _cameraMain.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
                // Ray ray = Camera.main.ScreenPointToRay(position);
                Ray ray = new Ray(position, _cameraMain.transform.forward);
                RaycastHit hit;
                Debug.DrawRay(position, _cameraMain.transform.forward * 100, Color.green, 1f);

            if (Physics.Raycast(ray, out hit))
            {
                _gamePiece = hit.collider?.GetComponent<GamePiece>();

                if (_gamePiece != null)
                {
                    if (hit.transform == _gamePiece.transform && _isPicked == false)
                    {
                        transform.localScale *= 2;
                        _isPicked = true;

                    }


                    else if (hit.transform == _gamePiece.transform && _isPicked == true)
                    {
                        transform.localScale /= 2;
                        _isPicked = false;
                    }
                    TouchPressed.Invoke(hit.collider);
                }

                
                }

                
            } 
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
