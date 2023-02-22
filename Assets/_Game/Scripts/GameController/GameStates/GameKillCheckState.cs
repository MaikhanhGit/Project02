using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKillCheckState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private State _previousState;

        public GameKillCheckState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        // get what the previous state was
        _previousState = _stateMachine.PreviousState;
        // check for Kills

    }

    public override void Exit()
    {
        if(_previousState == _stateMachine.PlayerOnePlayState)
        {
            _stateMachine.ChangeState(_stateMachine.PlayerTwoPlayState);
        }
        else if(_previousState == _stateMachine.PlayerTwoPlayState)
        {
            _stateMachine.ChangeState(_stateMachine.PlayerOnePlayState);
        }
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }
}
