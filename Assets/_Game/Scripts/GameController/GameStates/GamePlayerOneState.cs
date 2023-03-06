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
        Debug.Log("Enter Player 1 State");
        _availableMoves = null;
        _gamePiecePickedUp = false;
        _gameBoard = _controller.GameBoard;
        _controller.SetCurrentPlayerState(_stateMachine.CurrentState);
        _controller.InputManager.TouchPressed += OnPick;
        _controller.InputManager.TouchReleased += OnRelease;              
                 
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Player 1 State");
        _controller.PlayerOneStateText.SetActive(false);
        _controller.InputManager.TouchPressed -= OnPick;
        _controller.InputManager.TouchReleased -= OnRelease;      
        
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

    private void OnRelease()
    {

    }
   
        // check Kills

        // check Win/Lose/Tie


        /* PLACE HOLDER
        // check if touch, if yes, move player 1 to touch position

        if(StateDuration <= 1 && _controller?.Input?.IsTapPressed == true)
        {
            _controller.PlayerOneStateText.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.GameWinState);
        }
        else if (StateDuration < _controller.TimeLimitToLose && _controller?.Input?.IsTapPressed == true)
        {
            Exit();
            //Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionInput.ReadValue<Vector2>());
            //position.z = _playerOne.transform.position.z;
            //_playerOne.transform.position = position;            
            //_playerOne?.MovePlayerOne(position);
        }
        else if (StateDuration >= _controller.TimeLimitToLose)
        {
            _controller.PlayerOneStateText.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.GameLoseState);
        }
        */

    
    
        
}
