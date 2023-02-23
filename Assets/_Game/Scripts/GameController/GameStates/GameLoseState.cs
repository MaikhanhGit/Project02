using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private float _delayExitDuration = 2;

    public GameLoseState (GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("LOSE STATE");
        // sfx
        AudioHelper.PlayClip2D(_controller.LoseSFX, 1);
        _controller.LoseStateUI.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _controller.LoseStateUI.SetActive(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
       /*
        if (_controller?.Input?.IsTapPressed == true)
        {            
            if(StateDuration >= _delayExitDuration)
            {
                // Move to Main Menu
                Debug.Log("Move to Main Menu");
                _controller.MainMenu.LoadScene(0);
            }
            
        }
       */
    }
}
