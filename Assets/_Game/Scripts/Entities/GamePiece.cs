using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GamePieceType
{
    PlayerOnePiece = 0,
    PlayerTwoPiece = 1
}
public class GamePiece : MonoBehaviour
{
    public GamePieceType Type;
    public int Team;
    public int CurrentX;
    public int CurrentY;
    
    private Vector3 _desiredPosition;
    private bool _piecePickedUp = false;

    public bool PiecePickedUp => _piecePickedUp;

    private void Awake()
    {
        
    }

    public void SetPosition(Vector3 position, bool force = false)
    {
        // TODO: player sfx

        _desiredPosition = position;
        if(force == true)
        {
            transform.position = _desiredPosition;
        }
    }

    public void PickedUp()
    {        
        if(_piecePickedUp == false)
        {
            Transform transform = gameObject.transform;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            transform.localScale += new Vector3(0.1f, 0.01f, 0.01f);
            _piecePickedUp = true;           
        }
        else if(_piecePickedUp == true)
        {
            PutDown();
        }
        
    }

    public void PutDown()
    {        
            Debug.Log("Decrease size");
            Transform transform = this.gameObject.transform;
            transform.position = new Vector3(transform.position.x, -1, transform.position.z);
            transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
            _piecePickedUp = false;      
        
    }
}
