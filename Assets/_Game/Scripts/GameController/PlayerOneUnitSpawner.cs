using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneUnitSpawner : MonoBehaviour
{
    public PlayerOne Spawn(PlayerOne playerOnePrefab, Transform location)
    {
        // spawn and hold on to the component type
        PlayerOne newUnit = Instantiate(playerOnePrefab, location.position, location.rotation);
        // TODO do setup here if needed, spawn effects, etc.
        return newUnit;
    }
}
