using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayerOneState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private InputAction _touchPositionInput;
    private PlayerOne _playerOne;
    private GamePiece _gamePiece;

    private string _playerOneTag = "PlayerOne";
    private bool _gamePiecePickedUp = false;
        
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

        _touchPositionInput = _controller?.Input?.TouchManager?.TouchPositionAction;
        _playerOne = _controller?.PlayerOnePrefab;             
    }

    public override void Exit()
    {
        base.Exit();

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
        else if(_controller?.Input?.IsTapPressed == false)
        {
            _gamePiecePickedUp = false;
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
    
        
}
