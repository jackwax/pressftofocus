using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetUtil : MonoBehaviour {

    // A util class for all canvas widgets
    // Allows us to activate / deactivate widgets as needed.
    [SerializeField]
    private List<GameObject> uielements;
    [SerializeField]
    private bool startOff = true;





	void Start () {
        uielements = _collectElements();
        if (startOff) { this.gameObject.SetActive(false); }
	}
	

    private List<GameObject> _collectElements()
    {
        List<GameObject> temp = new List<GameObject>();

        foreach (Transform child in transform)
        {
            temp.Add(child.gameObject);
        }

        return temp;
    }

    public void ToggleWidget(bool Active)
    {
        foreach (GameObject go in uielements)
        {
            go.SetActive(Active);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
