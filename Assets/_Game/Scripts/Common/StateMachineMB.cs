using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
    public State CurrentState { get; private set; }
    private State _previousState;

    private bool _inTransition = false;

    public void ChangeState(State newState)
    {
        // ensure wew're ready for a new State
        if (CurrentState == newState || _inTransition)
            return;

        ChangeStateSequence(newState);
    }

    private void ChangeStateSequence(State newState)
    {
        _inTransition = true;
        // run our exit sequence before moving to new state
        CurrentState?.Exit();
        if(newState != null) 
             StoreStateAsPrevious(CurrentState, newState);

        CurrentState = newState;

        // begin our new EnterSequence
        CurrentState?.Enter();
        _inTransition = false;        
    }

    private void StoreStateAsPrevious(State currentState, State newState)
    {
        // if there is no previous state, this is our first
        if (_previousState == null && currentState != null)
            _previousState = newState;   
        // otherwise, store our current state as previous
        else if(_previousState != null && currentState != null)
        {
            _previousState = CurrentState;
        }
    }

    public void ChangeStateToPrevious()
    {
        if (_previousState != null)
            ChangeState(_previousState);
        else
            Debug.LogWarning("There is no previous state to change to!");
    }

    // virtual allows us to override in our FSM to chech for
    // 'AnyState' types of conditions
    protected virtual void Update()
    {
        // simulate update ticks in states
        if (CurrentState != null && !_inTransition)
        {
            CurrentState.Tick();
        }
    }

    protected virtual void FixedUpdate()
    {
        // simulate FixedUpdate in states
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

    protected virtual void OnDestroy()
    {
        CurrentState?.Exit();
    }



}