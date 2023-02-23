using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private float _delayExitDuration = 2;

    public GameWinState (GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("WON STATE");
        // sfx
        AudioHelper.PlayClip2D(_controller.WinSFX, 1);
        _controller.WinStateUI.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _controller.WinStateUI.SetActive(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        /*
        if(_controller?.Input?.IsTapPressed == true)
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
