using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMoveState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private State _previousState;    
    
    private string _highlightTag = "HighLight";
           
    public GameMoveState(GameFSM stateMachine, GameController controller, State previousState)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _previousState = previousState;       
    }

    public override void Enter()
    {
        base.Enter();
        // UI

        // touch input
        _controller.InputManager.TouchPressed += OnTouch;

    }

    public override void Exit()
    {
        base.Exit();
        _controller.InputManager.TouchPressed -= OnTouch;
    }

   
    public override void Tick()
    {
        base.Tick();
    }

    private void OnTouch(Collider collider)
    {
        GamePiece piece = _controller.CurrentGamePiece;

        if (collider.tag == _highlightTag)
        {                               
            GameObject tile = collider.gameObject;                        
            Transform newPosition = tile.transform;

            piece.SetPosition(newPosition.position, true);
            piece.ResetSize();

            _stateMachine.ChangeState(_stateMachine.KillCheckState);
        }
        else
        {
            piece.PutDown();
            _stateMachine.ChangeState(_previousState);
        }
    }
}
