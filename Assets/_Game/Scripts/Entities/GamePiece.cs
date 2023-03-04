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
    public int CurrentZ;    
        
    private bool _piecePickedUp = false;
    private Vector3 _currentTransform;
    private int _tileSize = 1;    
    private Vector3 _originalSize;
    private GetAvailableMoves _getAvailableMoves;

    public bool PiecePickedUp => _piecePickedUp;

    private void Start()
    {
        
        _originalSize = transform.localScale;
    }

    private void Update()
    {
        CurrentX = (int)transform.position.x;
        CurrentZ = (int)transform.position.z;

    }

    public void SetPosition(Vector3 position, bool force = false)
    {
        // TODO: player sfx
        Vector3 desiredPosition;
        desiredPosition = position;
        if(force == true)
        {
            transform.position = desiredPosition;
        }
    }

    public void PickedUp()
    {    
        if(_piecePickedUp == true)
        {            
            PutDown();
        }
        else if(_piecePickedUp == false)
        {
            Debug.Log("Up");
            _currentTransform = gameObject.transform.position;
            Transform transform = gameObject.transform;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            transform.localScale += new Vector3(1f, 0.5f, 0.5f);
            _piecePickedUp = true;            
        }                
    }

    public void PutDown()
    {
        Debug.Log("Down");
        Transform transform = this.gameObject.transform;
        transform.position = _currentTransform;
        ResetSize();
    }
    
    public void ResetSize()
    {
        transform.localScale = _originalSize;
        _piecePickedUp = false;
    }
}
