using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameKillCheckState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private State _previousPlayerState;
    private GamePiece curPiece;
    GamePiece[,] board;
    KillCheck killCheck;
    private float _delayExitDuration = 1.1f;
    private int _playerOneCount = 7;
    private int _playerTwoCount = 7;
    private bool _alertSentToOne = false;
    private bool _alertSentToTwo = false;
    
    public GameKillCheckState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;        
    }

    public override void Enter()
    {
        base.Enter();        
        StartKillCheck();
    }

    public override void Tick()
    {
        base.Tick();

        if (_playerOneCount <= 3 && _alertSentToOne == false)
        {
            _controller.PlayerOneRedOn();
            _alertSentToOne = true;
        }

        if (_playerTwoCount <= 3 && _alertSentToTwo == false)
        {
            _controller.PlayerTwoRedOn();
            _alertSentToTwo = true;
        }

        if (_playerOneCount <= 0)
        {
            _controller.SetWonTeam( 1);
            _stateMachine.ChangeState(_stateMachine.EndGameState);
        }
        else if(_playerTwoCount <= 0)
        {
            _controller.SetWonTeam(0);
            _stateMachine.ChangeState(_stateMachine.EndGameState);
        }
        else if(_playerOneCount == 1 && _playerTwoCount == 1)
        {
            _controller.SetWonTeam(2);
            _stateMachine.ChangeState(_stateMachine.EndGameState);
        }

        else if (StateDuration >= _delayExitDuration)
        {
            StartExit();
        }
    }
    
    private void StartKillCheck()
    {
        _previousPlayerState = _controller.CurrentPlayerState;
        board = _controller.GameBoard.BoardPieces;
        curPiece = _controller.CurrentGamePiece;
        if (curPiece)
        {
            killCheck = curPiece.GetComponent<KillCheck>();
            int kills = killCheck.CheckForKills(board);
            CheckEndGame(kills);
        }
    }

    private void CheckEndGame(int kills)
    {        
        if (_previousPlayerState == _stateMachine.PlayerOnePlayState)
        {
            _playerTwoCount -= kills;            
        }
        else if (_previousPlayerState == _stateMachine.PlayerTwoPlayState)
        {
            _playerOneCount -= kills;            
        }

        Debug.Log("Player One Count: " + _playerOneCount);
        Debug.Log("Player Two Count: " + _playerTwoCount);
    }
    

    private void StartExit()
    {                       
        if (_previousPlayerState == _stateMachine.PlayerOnePlayState)
        {
            _controller.PlayerOneStateText?.SetActive(false);
            _controller.PlayerTwoTurnSFX();            
            _stateMachine.ChangeState(_stateMachine.PlayerTwoPlayState);
        }
        else if (_previousPlayerState == _stateMachine.PlayerTwoPlayState)
        {
            _controller.PlayerTwoStateText?.SetActive(false);
            _controller.PlayerOneTurnSFX();            
            _stateMachine.ChangeState(_stateMachine.PlayerOnePlayState);
        }
    }

    public override void Exit()
    {       
        base.Exit();       
    }



}
