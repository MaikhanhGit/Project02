using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKillCheckState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private State _previousPlayerState;
    private GamePiece curPiece;
    GamePiece[,] board;
    KillCheck killCheck;
    private float _delayExitDuration = 1;
    private int _playerOneCount = 7;
    private int _playerTwoCount = 7;
    
    public GameKillCheckState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;        
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter Kill Check State");
        
        StartKillCheck();
    }

    public override void Tick()
    {
        base.Tick();        

        if(_playerOneCount <= 0)
        {
            _controller.SetWonTeam(1);
        }
        else if(_playerTwoCount <= 0)
        {
            _controller.SetWonTeam(0);
        }
        else if(_playerOneCount == 1 && _playerTwoCount == 1)
        {
            _controller.SetWonTeam(2);
        }

        if (StateDuration >= _delayExitDuration)
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

            Debug.Log("Killed: " + kills);
            //TODO: UI show kills            

            //_controller.KillCheckText.SetActive(true);
        }
    }

    private void CheckEndGame(int kills)
    {
        Debug.Log("previous player: " + _previousPlayerState);
        
        if (_previousPlayerState == _stateMachine.PlayerOnePlayState)
        {
            _playerTwoCount -= kills;
            Debug.Log("player 2 count: " + _playerTwoCount);

        }
        else if (_previousPlayerState == _stateMachine.PlayerTwoPlayState)
        {
            _playerOneCount -= kills;
            Debug.Log("player 1 count: " + _playerOneCount);
        }
    }

    private void StartExit()
    {               
        //_controller.KillCheckText.SetActive(false);

        if (_previousPlayerState == _stateMachine.PlayerOnePlayState)
        {
            Debug.Log("Moving To Player 2");
            _stateMachine.ChangeState(_stateMachine.PlayerTwoPlayState);
        }
        else if (_previousPlayerState == _stateMachine.PlayerTwoPlayState)
        {
            Debug.Log("Moving To Player 1");
            _stateMachine.ChangeState(_stateMachine.PlayerOnePlayState);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Kill Check State");
        base.Exit();
    }



}
