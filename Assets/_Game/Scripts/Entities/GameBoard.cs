using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Material _tileMaterial;
    [SerializeField] private float _tileSize = 1;
    [SerializeField] private float _yOffset = 0.2f;
    [SerializeField] private Vector3 _boardCenter = Vector3.zero;
    // [SerializeField] private GamePiece _gamePiece;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private GameObject[,] _tiles;
    [SerializeField] private Vector3 _bounds;


    private GamePiece[,] _gamePieces;
    private const float TILE_COUNT_X = 5;
    private const float TILE_COUNT_Y = 5;
    private int _playerOneTeam = 0;
    private int _playerTwoTeam = 1;
    private string _tileTag = "Tile";
    private GamePieceType _gamePieceTeam;
    private bool _playerOnesTurn = false;
    private bool _playerTwosTurn = false;


    private void Awake()
    {
        
    }

    public void GenerateBoard()
    {
        GenerateTiles(_tileSize, TILE_COUNT_X, TILE_COUNT_Y);
        SpawnGamePieces();
        PositionGamePieces();
        
    }

    private void GenerateTiles(float tileSize, float tileCountX, float tileCountY)
    {
        _yOffset += transform.position.y;
        _bounds = new Vector3((tileCountX / 2) * tileSize, 0,
            (tileCountX / 2) * tileSize) + _boardCenter;
        _tiles = new GameObject[(int)tileCountX, (int)tileCountX];

        for (int x = 0; x < tileCountX; x++)
        {
            for (int y = 0; y < tileCountY; y++)
            {
                _tiles[x, y] = GenerateSingleTile(tileSize, x, y);
            }                
        }
    }
    
    private GameObject GenerateSingleTile(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1}", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = _tileMaterial;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, _yOffset, y * tileSize) - _bounds;
        vertices[1] = new Vector3(x * tileSize, _yOffset, (y + 1) * tileSize) - _bounds;
        vertices[2] = new Vector3((x + 1) * tileSize, _yOffset, y * tileSize) - _bounds;
        vertices[3] = new Vector3((x + 1) * tileSize, _yOffset, (y + 1) * tileSize) - _bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer(_tileTag);
        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }

    private void SpawnGamePieces()
    {
        _gamePieces = new GamePiece[(int)TILE_COUNT_X, (int)TILE_COUNT_Y];

        // player 1 pieces
        _gamePieces[0, 1] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);
        _gamePieces[4, 1] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);
        for (int i = 0; i < TILE_COUNT_X; i++)
        {
            _gamePieces[i, 0] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);
        }

        // player 2 pieces
        _gamePieces[0, 3] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        _gamePieces[4, 3] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        for (int i = 0; i < TILE_COUNT_X; i++)
        {
            _gamePieces[i, 4] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        }
    }

    private GamePiece SpawnSinglePiece(GamePieceType type, int team)
    {
        GamePiece piece = Instantiate(_prefabs[(int)team], transform).GetComponent<GamePiece>();
        piece._type = type;
        piece._team = team;

        return piece;
    }

    private void PositionGamePieces()
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
        {
            for (int y = 0; y < TILE_COUNT_Y; y++)
            {
                if (_gamePieces[x, y] != null)
                {
                    PositionSinglePiece(x, y, true);
                }
            }
        }
    }

    private void PositionSinglePiece(int x, int y, bool force = false)
    {        
        _gamePieces[x, y]._currentX = x;
        _gamePieces[x, y]._currentY = y;
        _gamePieces[x, y].SetPosition(GetTileCenter(x, y), force);        
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        return new Vector3 (x * _tileSize, _yOffset, y * _tileSize) - _bounds
                            + new Vector3(_tileSize / 2, 0, _tileSize / 2);
    }

}
