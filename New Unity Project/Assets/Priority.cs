using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priority : MonoBehaviour {

    //a tiny class to allow gameobjects to add themselves to a list that GameManager can call, and sort themselves by priority
    public int priority;
    public static List<Priority> GOSTATES;


	// Use this for initialization
	void Start () {
        if (GOSTATES == null)
        {
            GOSTATES = new List<Priority>();
        }

        GOSTATES.Add(this);
        print(GOSTATES.Count);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
