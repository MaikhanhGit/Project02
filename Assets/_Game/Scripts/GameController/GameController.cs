using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;
    [SerializeField] private float _setupStateDuration = 5;
    [SerializeField] private float _timeLimitToWin = 1;
    [SerializeField] private float _timeLimitToLose = 5;

    [Header("Dependencies")]
    [SerializeField] private GamePiece _playerOnePrefab;
    [SerializeField] private GamePiece _playerTwoPrefab;
    [SerializeField] private Transform _playerOneSpawnPosition;
    [SerializeField] private Transform _playerTwoSpawnPosition;
    [SerializeField] private PlayerOneUnitSpawner _playerOneUnitSpawner;
    [SerializeField] private PlayerTwoUnitSpawner _playerTwoUnitSpawner;
    [SerializeField] private TouchManager _inputManager;
    [SerializeField] private GameBoard _gameBoard;

    [Header("UI")]
    [SerializeField] private GameObject _setupStateText;
    [SerializeField] private GameObject _playerOneStateText;
    [SerializeField] private GameObject _playerTwoStateText;        
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameObject _playerOneWonPromp;
    [SerializeField] private GameObject _playerTwpWonPromp;

    [Header ("SFX")]     

    private GamePiece _curGamePiece;
    private State _curPlayerState;
    private GameObject[,] _highlightedTiles;
    private int _wonTeam = -1;    
        
    public float TapLimitDuration => _tapLimitDuration;
    public float SetupStateDuration => _setupStateDuration;
    public GamePiece PlayerOnePrefab => _playerOnePrefab;
    public GamePiece PlayerTwoPrefab => _playerTwoPrefab;
    public Transform PlayerOneSpawnPosition => _playerOneSpawnPosition;
    public Transform PlayerTwoSpawnPosition => _playerTwoSpawnPosition;
    public PlayerOneUnitSpawner PlayerOneUnitSpawner => _playerOneUnitSpawner;
    public PlayerTwoUnitSpawner PlayerTwoUnitSpawner => _playerTwoUnitSpawner;
    public TouchManager InputManager => _inputManager;
    public GameBoard GameBoard => _gameBoard;
    public GameObject SetupStateText => _setupStateText;
    public GameObject PlayerOneStateText => _playerOneStateText;
    public GameObject PlayerTwoStateText => _playerTwoStateText;        
    public GameObject[,] HighlightedTiles => _highlightedTiles;
    public MainMenu MainMenu => _mainMenu;
    public GamePiece CurrentGamePiece => _curGamePiece;
    public State CurrentPlayerState => _curPlayerState;
    public int WonTeam => _wonTeam;       
    
    public void SetCurrentGamePiece(GamePiece piece)
    {
        _curGamePiece = piece;
    }

    public void ClearCurrentGamePiece()
    {
        if(_curGamePiece != null)
        {
            _curGamePiece = null;
        }
    }

    public void SetCurrentPlayerState(State state)
    {
        _curPlayerState = state;
    }

    public void SetHightlightedTiles(GameObject[,] tiles)
    {
        _highlightedTiles = tiles;
    }

    public void ClearHighlightedTiles()
    {
        _gameBoard.RemoveHighLightTiles(_highlightedTiles);
        _highlightedTiles = null;
        
    }

    public void SetWonTeam(int team)
    {
        _wonTeam = team;               
    }
        
    
}
