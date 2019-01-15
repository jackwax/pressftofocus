using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenjiChatState : IState {

    GameObject parent;

    public BenjiChatState(GameObject _parent)
    {
        parent = _parent;
    }


	// Use this for initialization
	public void Enter()
    {
        parent.SetActive(true);
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        parent.SetActive(false);
    }


}
