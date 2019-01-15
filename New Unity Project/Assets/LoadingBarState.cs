using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBarState : IState {

    GameObject parent;
    FillAnimation fillAnim;
    AudioClip ac;
    private System.Action callback;

    //add callback function to it that'll execute and swap out states
    public LoadingBarState(GameObject _parent, System.Action _callback )
    {
        parent = _parent;
        fillAnim = parent.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<FillAnimation>();
        callback = _callback;
    }


	public void Enter()
    {
        //getting way too many children... maybe I'll refactor this later...
        parent.SetActive(true);

        //soundManager.
        fillAnim.StartCoroutine("AnimateFill");

    }

    public void Execute()
    {
        if (fillAnim.animCompleted == true)
        {
            //callback function
            callback();
        }
        //Do nothing
    }

    public void Exit()
    {
        parent.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
