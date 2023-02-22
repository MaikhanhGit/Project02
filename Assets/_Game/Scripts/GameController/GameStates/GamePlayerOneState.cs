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

    public GamePlayerOneState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("STATE: Player One Play State");
        Debug.Log("Listen for Player Inputs");
        Debug.Log("Display Player HUD");

        _touchPositionInput = _controller?.Input?.TouchManager?.TouchPositionAction;
        _playerOne = _controller?.PlayerOnePrefab;        
    }

    public override void Exit()
    {
        base.Exit();
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

        
        // check for win condition

        // check if touch, if yes, move player 1 to touch position
        if (_controller?.Input?.IsTapPressed == true)
        {
            // placeholder
            Exit();

            //Vector3 position = Camera.main.ScreenToWorldPoint(_touchPositionInput.ReadValue<Vector2>());
            //position.z = _playerOne.transform.position.z;
            //_playerOne.transform.position = position;            
            //_playerOne?.MovePlayerOne(position);
        }
        else if(StateDuration >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose!");
        }

        // check for lose condition
    }
}
