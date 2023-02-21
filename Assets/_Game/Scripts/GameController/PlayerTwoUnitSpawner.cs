using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoUnitSpawner : MonoBehaviour
{
    public PlayerTwo Spawn(PlayerTwo playerTwoPrefab, Transform location)
    {
        // spawn and hold on to the component type
        PlayerTwo newUnit = Instantiate(playerTwoPrefab, location.position, location.rotation);
        // TODO do setup here if needed, spawn effects, etc.
        return newUnit;
    }
}
