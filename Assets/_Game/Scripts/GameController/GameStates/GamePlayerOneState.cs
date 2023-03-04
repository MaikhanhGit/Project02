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
        //_controller.PlayerOneStateText.SetActive(true);
        _availableMoves = null;
        _gameBoard = _controller.GameBoard;
        _controller.SetCurrentPlayerState(_stateMachine.CurrentState);
        _controller.InputManager.TouchPressed += OnPick;
        _controller.InputManager.TouchReleased += OnRelease;
              
                 
    }

    public override void Exit()
    {
        base.Exit();
        _controller.InputManager.TouchPressed -= OnPick;
        _controller.InputManager.TouchReleased -= OnRelease;      
        //_controller.PlayerOneStateText.SetActive(false);
        _stateMachine.ChangeState(_stateMachine.KillCheckState);
        
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        
 
        /*
        Debug.Log("Checking for Win Condition");
        Debug.Log("Checking for Lose Condition");
        Debug.Log("Checking for Tie Condition");
        */

        // check input

        /*
        if (_controller?.Input?.IsTapPressed == true )
        {           
            if (_controller.Input.TouchManager.HitObjectCollider?.tag == _playerOneTag)
            {
                _gamePiece =
                        _controller.Input.TouchManager.HitObjectCollider.GetComponent<GamePiece>();

                bool _currentlyPickedUp = _gamePiece.PiecePickedUp;
                Debug.Log(_currentlyPickedUp);
                if (_currentlyPickedUp == false)
                {
                    _gamePiece.PickedUp();
                    _gamePiecePickedUp = true;
                }
                
                else if(_currentlyPickedUp == true)
                {
                    _gamePiece.PutDown();
                    _gamePiecePickedUp = false;
                }                
                              
            }
        }
        */
                        


            /*
             Ray ray = _controller.Input.TouchManager.TouchRay;
             RaycastHit hit = _controller.Input.TouchManager.TouchRayHit;
             Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionInput.ReadValue<Vector2>());
             Vector2 touchPosition = new Vector2(position.x, position.y);
             Collider2D collider2D = Physics2D.OverlapPoint(touchPosition);
             string name = collider2D?.gameObject.name.ToString();

             if (collider2D != null && collider2D.tag == _playerOne.tag)
             {

                 GamePiece gamePiece = hit.collider.gameObject.GetComponent<GamePiece>();
                 position.y = gamePiece.transform.position.y;
                 gamePiece.transform.position = position;
             }
            */


            /*
            Ray ray = _controller.Input.TouchManager.TouchRay;
            RaycastHit hit = _controller.Input.TouchManager.TouchRayHit; 

            if (Physics.Raycast(ray, out hit))
                {              
                    PlayerOne gamepiece = hit.collider?.gameObject.GetComponent<PlayerOne>();
                    if(gamepiece != null)
                    {
                        Debug.Log("Reading Input");
                    }


                    if (hit.collider?.tag == _playerOneTag)
                    {
                        _touchPositionInput = _controller?.Input?.TouchManager?.TouchPositionAction;
                        GameObject gamePiece = hit.collider.gameObject;

                        Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionInput.ReadValue<Vector2>());
                        position.y = gamePiece.transform.position.y;
                        gamePiece.transform.position = position;
                    }
                }
              */

        }
    private void OnPick(Collider collider)
    {              
        if(collider.tag == _playerOneTag)
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
