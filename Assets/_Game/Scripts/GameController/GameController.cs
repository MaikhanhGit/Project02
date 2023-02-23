using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;
    [SerializeField] private float _setupStateDuration = 5;

    [Header("Dependencies")]
    [SerializeField] private PlayerOne _playerOnePrefab;
    [SerializeField] private PlayerTwo _playerTwoPrefab;
    [SerializeField] private Transform _playerOneSpawnPosition;
    [SerializeField] private Transform _playerTwoSpawnPosition;
    [SerializeField] private PlayerOneUnitSpawner _playerOneUnitSpawner;
    [SerializeField] private PlayerTwoUnitSpawner _playerTwoUnitSpawner;
    [SerializeField] private InputBroadcaster _input;

    [Header("UI")]
    [SerializeField] private GameObject _setupStateText;
    [SerializeField] private GameObject _playerOneStateText;
    [SerializeField] private GameObject _playerTwoStateText;
    [SerializeField] private GameObject _killCheckText;

    
    public float TapLimitDuration => _tapLimitDuration;
    public float SetupStateDuration => _setupStateDuration;
    public PlayerOne PlayerOnePrefab => _playerOnePrefab;
    public PlayerTwo PlayerTwoPrefab => _playerTwoPrefab;
    public Transform PlayerOneSpawnPosition => _playerOneSpawnPosition;
    public Transform PlayerTwoSpawnPosition => _playerTwoSpawnPosition;
    public PlayerOneUnitSpawner PlayerOneUnitSpawner => _playerOneUnitSpawner;
    public PlayerTwoUnitSpawner PlayerTwoUnitSpawner => _playerTwoUnitSpawner;
    public InputBroadcaster Input => _input;
    public GameObject SetupStateText => _setupStateText;
    public GameObject PlayerOneStateText => _playerOneStateText;
    public GameObject PlayerTwoStateText => _playerTwoStateText;
    public GameObject KillCheckText => _killCheckText;


    public void StartMyCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
