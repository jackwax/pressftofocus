//
//Coded by KiltedNinja
//kiltedninja@yahoo.com
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivationButtonScript : MonoBehaviour {

	private List<GameObject> ScrollingTexts;
	private List<ScrollyTextScript> ScriptReferences;
	
	void Start () {
		ScrollingTexts=new List<GameObject>();
		ScriptReferences=new List<ScrollyTextScript>();
		foreach (var ScrollingText in GameObject.FindGameObjectsWithTag("ScrollingText"))
		{
			ScrollingTexts.Add(ScrollingText);
			ScriptReferences.Add (ScrollingTexts[ScrollingTexts.Count-1].GetComponent<ScrollyTextScript>() );
		}
	}
	

	void OnGUI () {
		GUI.skin.button.fontSize =9;
		for (int i=0; i<ScrollingTexts.Count; i++) {
			if(!ScriptReferences[i].bSCROLLING){
			GUI.color = Color.green;
			GUI.contentColor = new Color (0.2f, 0.2f, 0.2f);
				if (GUI.Button (new Rect (5, 5+(i*22), 80, 16), ScrollingTexts[i].name)) {
				ScriptReferences[i].StartScrolling();
			}
			}
			if(ScriptReferences[i].bSCROLLING){
			GUI.color = Color.red;
			GUI.contentColor = new Color (0.2f, 0.2f, 0.2f);
				if (GUI.Button (new Rect (5, 5+(i*22), 80, 16), ScrollingTexts[i].name)) {
				ScriptReferences[i].StopScrolling();
			}
			}
		}
	}
}
