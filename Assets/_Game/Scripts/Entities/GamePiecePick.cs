using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePiecePick : MonoBehaviour
{
    [SerializeField] private InputAction Touch, TouchPos;

    private Vector3 _curScreenPos;
    private Vector3 _previousPos;
    private Camera _cameraMain;
    private bool isDragging = false;

    public bool IsPressed { get; private set; } = false;
        
    private Vector3 WorldPos
    {
        get
        {
            float y = _cameraMain.WorldToScreenPoint(transform.position).y;
           return _cameraMain.ScreenToViewportPoint(_curScreenPos + new Vector3(0, y, 0));
        }
    }
    
    private bool isClickedOn
    {
        get
        {
            Vector3 position = _cameraMain.ScreenToWorldPoint(_curScreenPos);
            Ray ray = _cameraMain.ScreenPointToRay(position);
            RaycastHit hit;
            Debug.DrawRay(position, _cameraMain.transform.forward * 100, Color.green, 1f);
            if (Physics.Raycast(ray, out hit))
            {
                return hit.transform == transform;
            }
            return false;
        }     
    }

    private void Awake()
    {
        _cameraMain = Camera.main;
        Touch.Enable();
        TouchPos.Enable();

        TouchPos.performed += 
            context => { _curScreenPos = context.ReadValue<Vector2>(); };

        Touch.performed += _ => { if(isClickedOn)
                                    PickGamePiece(); };       
    }

    private void PickGamePiece()
    {
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        transform.localScale += new Vector3(0.5f, 0.1f, 0.1f); ;
    }

   
        // drop

}

    
