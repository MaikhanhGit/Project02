using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayerTwoState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private InputAction _touchPositionInput;
    private PlayerOne _playerOne;

    private IEnumerator _coroutine;
    private float _exitDelay = 1;

    public GamePlayerTwoState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        // UI
        _controller.PlayerTwoStateText.SetActive(true);
        
    }

    public override void Exit()
    {
        base.Exit();

        _controller.PlayerTwoStateText.SetActive(false);
        _stateMachine.ChangeState(_stateMachine.KillCheckState);
        
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if (StateDuration <= 1 && _controller?.Input?.IsTapPressed == true)
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
    }

}
