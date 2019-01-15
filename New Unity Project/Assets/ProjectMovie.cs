using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProjectMovie : MonoBehaviour {

    public RawImage rI;
    public VideoPlayer vp;
    public IEnumerator e;

    public bool isFinished = false;


    // Use this for initialization
    //a basic util script for projecting a movieclip onto a UI element
    //this should be attached to a raw Image UI element and the coroutine can be called as needed


    void Start () {
        StartCoroutine(ProjectVideo());
		
	}

    public IEnumerator ProjectVideo()
    {
        vp.Prepare();
        WaitForSeconds w8 = new WaitForSeconds(1f);
        while (!vp.isPrepared)
        {
           yield return w8;
           break;
        }

        rI.texture = vp.texture;
        vp.Play();

        vp.loopPointReached += SetFinished;



    }

    public void SetFinished(VideoPlayer vp)
    {
        isFinished = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
