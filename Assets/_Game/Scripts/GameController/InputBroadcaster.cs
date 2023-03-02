using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    [field: SerializeField]
    public TouchManager TouchManager { get; private set; }

    public bool IsTapPressed { get; private set; } = false;
    public bool IsHoldPressed { get; private set; } = false;

    // TODO add other input events here

    private void OnEnable()
    {
        TouchManager.TouchPressed += OnTouch;
    }

    private void OnDisable()
    {
        
    }

    private void OnTouch(Collider objectCollider)
    {

    }

    private void Update()
    {
        // NOTE: put your Input/Detection here. this code
        // is just for simple example and does not account
        // for new Input System setup.
                
        
        if (TouchManager?.IsPressed == true)
        {
            //IsTapPressed = true;            
        }  
        
        else if (TouchManager?.IsPressed == false)
        {            
            //IsTapPressed = false;            
        }
        
        /*
        else if(TouchManager?.IsHold == true)
        {
            IsHoldPressed = true;
            Debug.Log("Holding");
        }
        else if(TouchManager?.IsHold == false)
        {
            IsHoldPressed = false;           
        } 
        */

    }

}
