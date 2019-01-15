using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillAnimation : MonoBehaviour {

    // Use this for initialization
    public bool animCompleted = false;

	void Start () {
		
	}

    public IEnumerator AnimateFill()
    {
        yield return new WaitForSeconds(4.0f);

        while (this.GetComponent<Image>().fillAmount < 0.99f)
        {
            float newFill = this.GetComponent<Image>().fillAmount + 0.05f;

            
            this.GetComponent<Image>().fillAmount = Mathf.Lerp(this.GetComponent<Image>().fillAmount, newFill, 0.05f);
            yield return null;

        }
        yield return new WaitForEndOfFrame();
        animCompleted = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
