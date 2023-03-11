using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayerTwoState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private GameBoard _gameBoard;
    private List<Vector2Int> _availableMoves;
    private GamePiece[,] _gamePieces;
    private GamePiece _curGamePiece;

    private string _playerTwoTag = "PlayerTwo";
    private bool _gamePiecePickedUp = false;
    private bool _gamePieceReleased = false;

    public GamePlayerTwoState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        
        _controller.PlayerTwoStateText.SetActive(true);
        _availableMoves = null;
        _gamePiecePickedUp = false;
        _gameBoard = _controller.GameBoard;
        _controller.SetCurrentPlayerState(_stateMachine.PlayerTwoPlayState);
        _controller.InputManager.TouchPressed += OnPick;
        _controller.InputManager.TouchReleased += OnRelease;

    }

    public override void Exit()
    {
        base.Exit();               
        _controller.InputManager.TouchPressed -= OnPick;
        _controller.InputManager.TouchReleased -= OnRelease;
        
        _stateMachine.ChangeState(_stateMachine.KillCheckState);        
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
        
    private void OnPick(Collider collider)
    {
        if (collider.tag == _playerTwoTag)
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

}
