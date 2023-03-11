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
    private float _delayExitDuration = 1.1f;
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
        StartKillCheck();
    }

    public override void Tick()
    {
        base.Tick();        

        if(_playerOneCount <= 0)
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
    }

    private void StartExit()
    {                       
        if (_previousPlayerState == _stateMachine.PlayerOnePlayState)
        {
            _controller.PlayerOneStateText?.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.PlayerTwoPlayState);
        }
        else if (_previousPlayerState == _stateMachine.PlayerTwoPlayState)
        {
            _controller.PlayerTwoStateText?.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.PlayerOnePlayState);
        }
    }

    public override void Exit()
    {       
        base.Exit();
    }



}
