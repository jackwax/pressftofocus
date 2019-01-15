using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretOfLifeMenu : IState {

    GameObject owner;
    //need to turn off objects based on what is being shown on screen.
    //need a list of buttons to hover over (this can be done in MenuScreenCanvas's own script)
    //buttons need their own trigger (this can be done on each individual button)


    public SecretOfLifeMenu(GameObject _parent)
    {
        owner = _parent;
    }


    public void Enter()
    {
        owner.SetActive(true);
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization




    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
