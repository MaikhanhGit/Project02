using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Material _tileMaterial;
    [SerializeField] private Material _hightlightMaterial;
    [SerializeField] private float _tileSize = 1;
    [SerializeField] private float _yOffset = 0.2f;
    [SerializeField] private Vector3 _boardCenter = Vector3.zero;
    [SerializeField] GameController _controller;
      
    [Header("Prefabs")]
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Vector3 _bounds;
        
    GetAvailableMoves _getAvailableMoves;
    private const float _tileCount_X = 5;
    private const float _tileCount_Z = 5;
    private int _playerOneTeam = 0;
    private int _playerTwoTeam = 1;
    private int _positionOffset = 2;
    private string _tileTag = "Tile";
    private string _highlightedTileTag = "HighLight";
    private GamePieceType _gamePieceTeam;
    private bool _playerOnesTurn = false;
    private bool _playerTwosTurn = false;
    private List<Vector2Int> _availableMoves = new List<Vector2Int>();
    private GameObject[,] _tiles;
    private GameObject[,] _hightlightedTiles;
    private GamePiece[,] _gamePieces;
    private GamePiece _gamePiece;

    public GameObject[,] Tiles => _tiles;

    private void Awake()
    {
        _getAvailableMoves = GetComponent<GetAvailableMoves>();
    }

    public void GenerateBoard()
    {
        GenerateTiles(_tileSize, _tileCount_X, _tileCount_Z);
        SpawnGamePieces();
        PositionGamePieces();
        
    }

    private void GenerateTiles(float tileSize, float tileCountX, float tileCountZ)
    {
        _yOffset += transform.position.y;
        _bounds = new Vector3((tileCountX / 2) * tileSize, 0,
            (tileCountX / 2) * tileSize) + _boardCenter;
        _tiles = new GameObject[(int)tileCountX, (int)tileCountX];

        for (int x = 0; x < tileCountX; x++)
        {
            for (int z = 0; z < tileCountZ; z++)
            {
                _tiles[x, z] = GenerateSingleTile(tileSize, x, z);
            }                
        }
    }
    
    private GameObject GenerateSingleTile(float tileSize, int x, int z)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Z:{1}", x, z));
        //tileObject.transform.parent = transform;        

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = _tileMaterial;
        tileObject.tag = _tileTag;

        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(x * tileSize, _yOffset, z * tileSize) - _bounds;
        vertices[1] = new Vector3(x * tileSize, _yOffset, (z + 1) * tileSize) - _bounds;
        vertices[2] = new Vector3((x + 1) * tileSize, _yOffset, z * tileSize) - _bounds;
        vertices[3] = new Vector3((x + 1) * tileSize, _yOffset, (z + 1) * tileSize) - _bounds;

        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.RecalculateNormals();

        //tileObject.layer = LayerMask.NameToLayer(_tileTag);
        tileObject.AddComponent<BoxCollider>();
        
        return tileObject;
    }

    private void SpawnGamePieces()
    {
        _gamePieces = new GamePiece[(int)_tileCount_X, (int)_tileCount_Z];

        // player 1 pieces
        _gamePieces[0, 1] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);        
        _gamePieces[4, 1] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);
        for (int i = 0; i < _tileCount_X; i++)
        {
            _gamePieces[i, 0] = SpawnSinglePiece(GamePieceType.PlayerOnePiece, _playerOneTeam);
        }

        // player 2 pieces
        _gamePieces[0, 3] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        _gamePieces[4, 3] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        for (int i = 0; i < _tileCount_X; i++)
        {
            _gamePieces[i, 4] = SpawnSinglePiece(GamePieceType.PlayerTwoPiece, _playerTwoTeam);
        }
    }

    private GamePiece SpawnSinglePiece(GamePieceType type, int team)
    {
        GamePiece piece = Instantiate(_prefabs[(int)team], transform).GetComponent<GamePiece>();
        piece.Type = type;
        piece.Team = team;

        return piece;
    }

    private void PositionGamePieces()
    {
        for (int x = 0; x < _tileCount_X; x++)
        {
            for (int z = 0; z < _tileCount_Z; z++)
            {
                if (_gamePieces[x, z] != null)
                {
                    PositionSinglePiece(x, z, true);
                }
            }
        }
    }

    private void PositionSinglePiece(int x, int z, bool force = false)
    {        
        _gamePieces[x, z].CurrentX = x;
        _gamePieces[x, z].CurrentZ = z;
        _gamePieces[x, z].SetPosition(GetTileCenter(x, z), force);        
    }

    private Vector3 GetTileCenter(int x, int z)
    {
        return new Vector3 (x * _tileSize, _yOffset, z * _tileSize) - _bounds
                            + new Vector3(_tileSize / 2, 0, _tileSize / 2);
    }
    
    
    public List<Vector2Int> GetMoves(Collider collider)
    {
        GameObject _gamePiece = collider.gameObject;

        _availableMoves = _gamePiece?.GetComponent<GetAvailableMoves>().AvailableMoves(_gamePieces);

        if (_availableMoves?.Count > 0)
        {
            HighlightTiles();
            return _availableMoves;
        }
        else
            return null;
    }

    private void HighlightTiles()
    {        
        for (int i = 0; i < _availableMoves.Count; i++)
        {
            //_hightlightedTiles[_availableMoves[i].x, _availableMoves[i].y] = _tiles[_availableMoves[i].x, _availableMoves[i].y];
            _tiles[_availableMoves[i].x, _availableMoves[i].y].tag = _highlightedTileTag;
            _tiles[_availableMoves[i].x, _availableMoves[i].y].GetComponent<MeshRenderer>().material = _hightlightMaterial;            
        }
        _controller.SetHightlightedTiles(_hightlightedTiles);
    }

    public void RemoveHighLightTiles(GameObject[,] tiles)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            _tiles[_availableMoves[i].x, _availableMoves[i].y].tag = _tileTag;
            _tiles[_availableMoves[i].x, _availableMoves[i].y].GetComponent<MeshRenderer>().material = _tileMaterial;
        }        
    }

}
