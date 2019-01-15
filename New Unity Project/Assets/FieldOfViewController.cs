using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewController : MonoBehaviour {

    // Use this for initialization
    public Camera cam;

    [SerializeField]
    private float lerpSpeed = 1f;

    [SerializeField]
    private float zoomMax = 30f;

    [SerializeField]
    private float zoomMin = 60f;

    [SerializeField]
    private float currentFOV = 45f;
    
	void Start () {
        cam = this.GetComponent<Camera>();

        

	}
	
	// Update is called once per frame
	void Update () {
        //print(currentFOV);
        

        
        //zoom
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            currentFOV = cam.fieldOfView - 6;
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            currentFOV = cam.fieldOfView + 6;
        }

        currentFOV = Mathf.Clamp(currentFOV, zoomMax, zoomMin);



        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, currentFOV, 0.1f);


    }
}
