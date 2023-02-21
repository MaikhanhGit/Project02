using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] private PlayerOne _playerOnePrefab;
    [SerializeField] private PlayerTwo _playerTwoPrefab;
    [SerializeField] private Transform _playerOneSpawnPosition;
    [SerializeField] private Transform _playerTwoSpawnPosition;
    [SerializeField] private PlayerOneUnitSpawner _playerOneUnitSpawner;
    [SerializeField] private PlayerTwoUnitSpawner _playerTwoUnitSpawner;
    [SerializeField] private InputBroadcaster _input;

    public float TapLimitDuration => _tapLimitDuration;

    public PlayerOne PlayerOnePrefab => _playerOnePrefab;
    public PlayerTwo PlayerTwoPrefab => _playerTwoPrefab;
    public Transform PlayerOneSpawnPosition => _playerOneSpawnPosition;
    public Transform PlayerTwoSpawnPosition => _playerTwoSpawnPosition;
    public PlayerOneUnitSpawner PlayerOneUnitSpawner => _playerOneUnitSpawner;
    public PlayerTwoUnitSpawner PlayerTwoUnitSpawner => _playerTwoUnitSpawner;
    public InputBroadcaster Input => _input;

    
}
