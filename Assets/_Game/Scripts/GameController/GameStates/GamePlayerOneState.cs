using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GamePlayerOneState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;            
    private GameBoard _gameBoard;
    private List<Vector2Int> _availableMoves;
    private GamePiece[,] _gamePieces;
    private GamePiece _curGamePiece;

    private string _playerOneTag = "PlayerOne";
    private bool _gamePiecePickedUp = false;
    private bool _gamePieceReleased = false;
   
    public GamePlayerOneState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        // UI
        _controller.PlayerOneStateText.SetActive(true);        
        _availableMoves = null;
        _gamePiecePickedUp = false;
        _gameBoard = _controller.GameBoard;
        _controller.SetCurrentPlayerState(_stateMachine.PlayerOnePlayState);
        _controller.InputManager.TouchPressed += OnPick;
        
    }

    public override void Exit()
    {
        base.Exit();        
        _controller.PlayerOneStateText.SetActive(false);
        _controller.InputManager.TouchPressed -= OnPick;          
        
        _stateMachine.ChangeState(_stateMachine.KillCheckState);
        
    }
    
    private void OnPick(Collider collider)
    {        
        if(_gamePiecePickedUp == false && collider.tag == _playerOneTag)
        {           
            _gamePiecePickedUp = true;
            
            _curGamePiece = collider.gameObject.GetComponent<GamePiece>();
            _controller.SetCurrentGamePiece(_curGamePiece);
            
            _curGamePiece.PickedUp();

            _availableMoves = _gameBoard.GetMoves(collider);

            if (_availableMoves != null)
            {                
                _gamePiecePickedUp = false;                
                // send available moves to GameController to clear later
                _stateMachine.ChangeState(_stateMachine.GameMoveState);
            }                 
            
        }
    }
   
        
}
