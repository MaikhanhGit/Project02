using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private float _delayExitDuration = 2;
    private int _wonTeam;
    private int _playerOneWon = 0;
    private int _playerTwoWon = 1;
    private int _tieGame = 2;

    public EndGameState (GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("End Game STATE");
        // sfx
        AudioHelper.PlayClip2D(_controller.WinSFX, 1);
        //_controller.WinStateUI.SetActive(true);

        _wonTeam = _controller.WonTeam;

        if(_wonTeam == _playerOneWon)
        {
            Debug.Log("Player 1 Won");
        }
        else if(_wonTeam == _playerTwoWon)
        {
            Debug.Log("Player 2 Won");
        }
        else if(_wonTeam == _tieGame)
        {
            Debug.Log("Tie");
        }
    }

    public override void Exit()
    {
        base.Exit();
        //_controller.WinStateUI.SetActive(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        /*
        if(_controller?.Input?.IsTapPressed == true)
        {
            if(StateDuration >= _delayExitDuration)
            {
                // Move to Main Menu
                Debug.Log("Move to Main Menu");
                _controller.MainMenu.LoadScene(0);
            }
            
        }
        */
    }
}
