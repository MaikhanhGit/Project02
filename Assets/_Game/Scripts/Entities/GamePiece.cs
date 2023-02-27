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
    public GamePieceType _type;
    public int _team;
    public int _currentX;
    public int _currentY;

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
