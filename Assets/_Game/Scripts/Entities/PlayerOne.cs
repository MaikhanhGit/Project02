using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOne : MonoBehaviour
{
    
    public void MovePlayerOne(Vector3 position)
    {
        
        this.gameObject.transform.position = position;
        
    }


}
 