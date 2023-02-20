using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField]
    public PlayerOne PlayerOnePrefab { get; private set; }

    [field: SerializeField]
    public Transform PlayerOneSpawnPosition { get; private set; }

    [field: SerializeField]
    public PlayerOneUnitSpawner PlayerOneUnitSpawner { get; private set; }

    [field: SerializeField]
    public InputBroadcaster Input { get; private set; }          
    
}
