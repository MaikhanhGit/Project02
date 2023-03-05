using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAvailableMoves : MonoBehaviour
{   
    private int _tileCount = 4;
    private int _zero = 0;
    private int _offSetZ = 2;
       
    public List<Vector2Int> AvailableMoves(GamePiece[,] board) 
    {        
        List<Vector2Int> r = new List<Vector2Int>();
        int pieceCurrentX = GetComponent<GamePiece>().CurrentX + _offSetZ;
        int pieceCurrentZ = GetComponent<GamePiece>().CurrentZ + _offSetZ;
        
        // Top
        if ((pieceCurrentZ + 1) <= _tileCount)
        {           
            if (board[pieceCurrentX, pieceCurrentZ + 1] == null)
            {                
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentZ + 1));
            }
        }        

        // Down
        if ((pieceCurrentZ - 1) >= _zero)
        {
            if (board[pieceCurrentX, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentZ - 1));
            }
        }

        // Right
        if((pieceCurrentX + 1) <= _tileCount)
        {
            if(board[pieceCurrentX + 1, pieceCurrentZ] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ));
            }
        }

        // Left
        if ((pieceCurrentX - 1) >= _zero)
        {            
            if (board[pieceCurrentX - 1, pieceCurrentZ] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ));
            }
        }

        // Top Right
        if((pieceCurrentX + 1) <= _tileCount && (pieceCurrentZ + 1) <= _tileCount)
        {
            if(board[pieceCurrentX + 1, pieceCurrentZ + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ + 1));
            }
        }

        // Bottom Right
        if ((pieceCurrentX + 1) <= _tileCount && (pieceCurrentZ - 1) >= _zero)
        {
            if (board[pieceCurrentX + 1, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ - 1));
            }
        }

        // Top Left
        if ((pieceCurrentX - 1) >= _zero && (pieceCurrentZ + 1) <= _tileCount)
        {
            if (board[pieceCurrentX - 1, pieceCurrentZ + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ + 1));
            }
        }

        // Bottom Left
        if ((pieceCurrentX - 1) >= _zero && (pieceCurrentZ - 1) >= _zero)
        {
            if (board[pieceCurrentX - 1, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ - 1));
            }
        }        

        return r;
    }
}
