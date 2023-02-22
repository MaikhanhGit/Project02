using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneUnitSpawner : MonoBehaviour
{
    private PlayerOne _instantiatedGameObject;

    public PlayerOne InstantiatedGameObject => _instantiatedGameObject;

    public PlayerOne Spawn(PlayerOne playerOnePrefab, Transform location)
    {
        // spawn and hold on to the component type
        PlayerOne _instantiatedGameObject = Instantiate(playerOnePrefab, location.position, Quaternion.identity);
        // TODO do setup here if needed, spawn effects, etc.
        return _instantiatedGameObject;
    }
}
