using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IState _currentlyRunningState;
    private IState _previousState;

    private void _setCurrentlyRunningState(IState newState)
    {
        this._currentlyRunningState = newState;
        this._currentlyRunningState.Enter();
    }


    public void ChangeState(IState newState)
    {
        //use setcurrentlyrunnignstate method that automatically executes enter
        if (this._currentlyRunningState != null)
        {
            this._currentlyRunningState.Exit();
        }
        this._previousState = this._currentlyRunningState;

        _setCurrentlyRunningState(newState);

    }

    public void ExecuteStateUpdate()
    {
        //var runningstate = this._currentlyRunningState;
        if (this._currentlyRunningState != null)
        {
            this._currentlyRunningState.Execute();
        }

    }

    public void SwitchToPreviousState()
    {
        ChangeState(this._previousState);
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
