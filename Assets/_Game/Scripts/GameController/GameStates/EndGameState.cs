using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private float _delayExitDuration = 2;
    private int _wonTeam;
    private int _playerOneWon = 0;
    private int _playerTwoWon = 1;
    private int _tieGame = 2;
    private int _playerOneWonScene = 2;
    private int _playerTwoWonScene = 3;
    private int _tieGameScene = 4;

    public EndGameState (GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.PlayerEndGameSFX();
        _wonTeam = _controller.WonTeam;

               
    }

    public override void Tick()
    {
        base.Tick();

        if (StateDuration >= _delayExitDuration)
        {
            if (_wonTeam == _playerOneWon)
            {
                SceneManager.LoadScene(_playerOneWonScene);
            }
            else if (_wonTeam == _playerTwoWon)
            {
                SceneManager.LoadScene(_playerTwoWonScene);
            }
            else if (_wonTeam == _tieGame)
            {
                SceneManager.LoadScene(_tieGameScene);
            }
        }

    }

    public override void Exit()
    {
        base.Exit();

        
    }

  
}
