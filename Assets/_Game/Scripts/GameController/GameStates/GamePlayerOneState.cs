using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerOneState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

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
    }

    public override void Exit()
    {
        base.Exit();
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
        if (_controller.Input.IsTapPressed == true)
        {
            Debug.Log("You Win!");
        }

        // check for lose condition
    }
}
