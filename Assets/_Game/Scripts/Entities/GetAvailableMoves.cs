using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAvailableMoves : MonoBehaviour
{   
    private int _TileCountX = 4;
    private int _TileCountY = 0;
    private int _offSetZ = 2;
    
    private void Awake()
    {        
        
    }

    public List<Vector2Int> AvailableMoves(GamePiece[,] board) 
    {        
        List<Vector2Int> r = new List<Vector2Int>();
        int pieceCurrentX = GetComponent<GamePiece>().CurrentX + _offSetZ;
        int pieceCurrentZ = GetComponent<GamePiece>().CurrentZ + _offSetZ;
        Debug.Log("x: " + pieceCurrentX);
        Debug.Log("z" + pieceCurrentZ);

        // Top
        if ((pieceCurrentZ + 1) < _TileCountX)
        {           
            if (board[pieceCurrentX, pieceCurrentZ + 1] == null)
            {
                Debug.Log("One");
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentZ + 1));
            }
        }        

        // Down
        if ((pieceCurrentZ - 1) >= _TileCountY)
        {
            if (board[pieceCurrentX, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX, pieceCurrentZ - 1));
            }
        }

        // Right
        if((pieceCurrentX + 1) <= _TileCountX)
        {
            if(board[pieceCurrentX + 1, pieceCurrentZ] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ));
            }
        }

        // Left
        if ((pieceCurrentX - 1) >= _TileCountY)
        {            
            if (board[pieceCurrentX - 1, pieceCurrentZ] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ));
            }
        }

        // Top Right
        if((pieceCurrentX + 1) <= _TileCountX && (pieceCurrentZ + 1) <= _TileCountX)
        {
            if(board[pieceCurrentX + 1, pieceCurrentZ + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ + 1));
            }
        }

        // Bottom Right
        if ((pieceCurrentX + 1) <= _TileCountX && (pieceCurrentZ - 1) >= _TileCountY)
        {
            if (board[pieceCurrentX + 1, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX + 1, pieceCurrentZ - 1));
            }
        }

        // Top Left
        if ((pieceCurrentX - 1) >= _TileCountY && (pieceCurrentZ + 1) <= _TileCountX)
        {
            if (board[pieceCurrentX - 1, pieceCurrentZ + 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ + 1));
            }
        }

        // Bottom Left
        if ((pieceCurrentX - 1) >= _TileCountY && (pieceCurrentZ - 1) >= _TileCountY)
        {
            if (board[pieceCurrentX - 1, pieceCurrentZ - 1] == null)
            {
                r.Add(new Vector2Int(pieceCurrentX - 1, pieceCurrentZ - 1));
            }
        }        

        return r;
    }
}
