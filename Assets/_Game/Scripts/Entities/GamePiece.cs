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
    public GamePieceType Type
        ;
    public int Team;
    public int CurrentX;
    public int CurrentY;
    

    private Vector3 _desiredPosition;   

    public void SetPosition(Vector3 position, bool force = false)
    {
        // TODO: player sfx

        _desiredPosition = position;
        if(force == true)
        {
            transform.position = _desiredPosition;
        }
    }
}
