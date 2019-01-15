using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopVideoState : IState {

    GameObject parent;
    System.Action doneFn;
    ProjectMovie projectorCtrl;

    public DesktopVideoState(GameObject _parent, System.Action _callbackFn)
    {
        parent = _parent;
        doneFn = _callbackFn;
        projectorCtrl = parent.GetComponent<ProjectMovie>();
    }


	// Use this for initialization
	public void Enter ()
    {
        parent.SetActive(true);
        projectorCtrl.StartCoroutine("ProjectVideo");

	}
	
	// Update is called once per frame
	public void Execute()
    {
        //if done
        if (projectorCtrl.isFinished == true)
        {
            doneFn();
        }

        //callback

    }

    public void Exit()
    {
        parent.SetActive(false);
    }


}
