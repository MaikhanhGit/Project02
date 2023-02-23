using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;

    // state variables here
    public GameSetupState SetupState { get; private set; }
    public GamePlayerOneState PlayerOnePlayState { get; private set; }
    public GamePlayerTwoState PlayerTwoPlayState { get; private set; }
    public GameKillCheckState KillCheckState { get; private set; }
    public GameWinState GameWinState { get; private set; }
    public GameLoseState GameLoseState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state instantiate here
        SetupState = new GameSetupState(this, _controller);
        PlayerOnePlayState = new GamePlayerOneState(this, _controller);
        PlayerTwoPlayState = new GamePlayerTwoState(this, _controller);
        KillCheckState = new GameKillCheckState(this, _controller);
        GameWinState = new GameWinState(this, _controller);
        GameLoseState = new GameLoseState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
