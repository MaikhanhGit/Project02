using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAvailableMoves : MonoBehaviour
{    
    private GameBoard _gameBoard;
    private GamePiece[,] _gamePieces;

    private void Awake()
    {
        _gameBoard = GetComponent<GameBoard>();
    }

    public List<Vector2Int> AvailableMoves(GamePiece currentPiece, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        int pieceCurrentX = currentPiece.CurrentX;
        int pieceCurrentY = currentPiece.CurrentY;

        // Up
        if ((pieceCurrentY + 1) < tileCountY)
        {
            if(_gamePieces[pieceCurrentX, pieceCurrentY + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentY + 1));
            }
        }

        // Down
        if ((pieceCurrentY - 1) >= 0)
        {
            if (_gamePieces[pieceCurrentX, pieceCurrentY - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentY - 1));
            }
        }

        // Right
        if((pieceCurrentX + 1) < tileCountX)
        {
            if(_gamePieces[pieceCurrentX + 1, pieceCurrentY] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentY));
            }
        }

        // Left
        if ((pieceCurrentX - 1) > 0)
        {
            if (_gamePieces[pieceCurrentX - 1, pieceCurrentY] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentY));
            }
        }

        // Top Right
        if((pieceCurrentX + 1) < tileCountX && (pieceCurrentY + 1) < tileCountY)
        {
            if(_gamePieces[pieceCurrentX + 1, pieceCurrentY + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentY + 1));
            }
        }

        // Bottom Right
        if ((pieceCurrentX + 1) < tileCountX && (pieceCurrentY - 1) >= 0)
        {
            if (_gamePieces[pieceCurrentX + 1, pieceCurrentY - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentY - 1));
            }
        }

        // Top Left
        if ((pieceCurrentX - 1) >= 0 && (pieceCurrentY + 1) < tileCountY)
        {
            if (_gamePieces[pieceCurrentX - 1, pieceCurrentY + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentY + 1));
            }
        }

        // Bottom Left
        if ((pieceCurrentX - 1) >= 0 && (pieceCurrentY - 1) >= 0)
        {
            if (_gamePieces[pieceCurrentX - 1, pieceCurrentY - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentY - 1));
            }
        }        

        return r;
    }
}
