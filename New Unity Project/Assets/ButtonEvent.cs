using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour {

    // Use this for initialization
    public UnityEvent functiontoCall;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && this.GetComponent<Image>().color == Color.green)
        {
            functiontoCall.Invoke();
        }
		
	}
}
