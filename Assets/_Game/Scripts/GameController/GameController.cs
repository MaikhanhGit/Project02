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
    [SerializeField] private GameObject _killCheckText;
    [SerializeField] private GameObject _winStateUI;
    [SerializeField] private GameObject _loseStateUI;
    [SerializeField] private MainMenu _mainMenu;

    [Header ("SFX")]
    [SerializeField] private AudioClip _winSFX;
    [SerializeField] private AudioClip _loseSFX;

    private GamePiece _curGamePiece;
    private State _curPlayerState;

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
    public GameObject KillCheckText => _killCheckText;
    public GameObject WinStateUI => _winStateUI;
    public GameObject LoseStateUI => _loseStateUI;
    public MainMenu MainMenu => _mainMenu;
    public GamePiece CurrentGamePiece => _curGamePiece;
    public State CurrentPlayerState => _curPlayerState;
    public float TimeLimitToWin => _timeLimitToWin;
    public float TimeLimitToLose => _timeLimitToLose;
    public AudioClip WinSFX => _winSFX;
    public AudioClip LoseSFX => _loseSFX;

    public void SetCurrentGamePiece(GamePiece piece)
    {
        _curGamePiece = piece;
    }
    
    public void SetCurrentPlayerState(State state)
    {
        _curPlayerState = state;
    }
    public void StartMyCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
