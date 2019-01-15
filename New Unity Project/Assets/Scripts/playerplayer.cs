using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerplayer : MonoBehaviour {

    // Use this for initialization
    bulletmove movement;

	void Start () {
        movement = GetComponent<bulletmove>();
        transform.localPosition = new Vector3 (0, 0, 0);
	}


    public void kill()
    {
        movement.lockMovement(true);
        Debug.Log("Player has been killed");
    }
	
	// Update is called once per frame
	void Update () {
		
	}



}
