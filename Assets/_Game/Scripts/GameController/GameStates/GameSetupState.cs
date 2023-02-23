using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private IEnumerator _coroutine;
    private float _playerOneSpawnWaitTime = 1;
    private float _playerTwoSpawnWaitTime = 2;

    // this is our 'contructor', called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Date");
        Debug.Log("STATE: Spawn Units");
        //UI
        _controller.SetupStateText.SetActive(true);

        // spawn players
        _coroutine = SpawnPlayers(_playerOneSpawnWaitTime, _playerTwoSpawnWaitTime);
        _controller.StartMyCoroutine(_coroutine);

    }

    public override void Exit()
    {
        base.Exit();

        _controller.SetupStateText.SetActive(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();        
        
        if (StateDuration > _controller.SetupStateDuration)
            _stateMachine.ChangeState(_stateMachine.PlayerOnePlayState);
    }

    private IEnumerator SpawnPlayers(float playerOneWaitTime, float playerTwoWaitTime)
    {
        yield return new WaitForSeconds(playerOneWaitTime);
        // spawn Player 1
        _controller.PlayerOneUnitSpawner.Spawn(_controller.PlayerOnePrefab,
            _controller.PlayerOneSpawnPosition);
        // spawn player 2
        yield return new WaitForSeconds(playerTwoWaitTime);
        _controller.PlayerTwoUnitSpawner.Spawn(_controller.PlayerTwoPrefab,
            _controller.PlayerTwoSpawnPosition);
    }

    
    
}
