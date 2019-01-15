using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameState : IState {

    GameObject parent;

    public GameGameState(GameObject go)
    {
        parent = go;
    }


	// Use this for initialization
	public void Enter () {
        parent.SetActive(true);
		
	}



    public void Execute()
    {

    }


    public void Exit()
    {

    }

}
