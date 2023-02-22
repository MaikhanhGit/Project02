using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOne : MonoBehaviour
{
    private InputBroadcaster _input;
    private TouchManager _touchManager;
    private InputAction _touchPosition;

    public bool IsOnPlayerOneTurn = false;
    public bool IsTapPressed = false;


    private void Awake()
    {
        _input = GetComponent<InputBroadcaster>();
        _touchManager = GetComponent<TouchManager>();
        _touchPosition = _touchManager.TouchPositionAction;
    }

    private void Update()
    {
        if (IsTapPressed && IsOnPlayerOneTurn)
        {
            //Vector3 position = Camera.main.ScreenToWorldPoint(_touchPosition.ReadValue<Vector2>());
            //position.z = this.transform.position.z;
            
        }
        
    }

    public void MovePlayerOne(Vector3 position)
    {       
        position.z = this.transform.position.z;
        this.transform.position = position;
        Debug.Log(this.transform.position);
        Debug.Log(position);
    }
}
