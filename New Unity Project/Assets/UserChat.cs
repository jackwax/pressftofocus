using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserChat : MonoBehaviour {

    TextMeshProUGUI text;

    //takes in a dialogue choice and types it out one by one

    // Use this for initialization
    private bool MessageDone;
    string message;

	void Start () {
        text = this.GetComponent<TextMeshProUGUI>();
        //StartCoroutine("TypeMessage", "Hey man. I'm good. How are you?");
        MessageDone = false;
	}

    public IEnumerator TypeMessage(string message)
    {
        foreach (char c in message)
        {
            yield return StartCoroutine("waitforinput", c);

            

        }
        while(!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        Reset();
    }

    public void Reset()
    {
        text.text = "";
        MessageDone = false;
    }

    public IEnumerator waitforinput(char c)
    {
        while (!Input.anyKeyDown || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(0) || Input.GetMouseButton(1)) 
        {
            yield return null;
        }
        text.text += c;
        yield return new WaitForEndOfFrame();
    }

}
