using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] private PlayerOne _playerOnePrefab;
    [SerializeField] private Transform _playerOneSpawnPosition;
    [SerializeField] private PlayerOneUnitSpawner _playerOneUnitSpawner;
    [SerializeField] private InputBroadcaster _input;

    public float TapLimitDuration => _tapLimitDuration;

    public PlayerOne PlayerOnePrefab => _playerOnePrefab;
    public Transform PlayerOneSpawnPosition => _playerOneSpawnPosition;
    public PlayerOneUnitSpawner PlayerOneUnitSpawner => _playerOneUnitSpawner;
    public InputBroadcaster Input => _input;

    
}
