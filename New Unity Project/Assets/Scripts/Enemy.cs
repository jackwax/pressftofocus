using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Use this for initialization
    string type;
    float speed = 0.5f;
    Vector3 normalizeDirection;
    bool isSeen;


	void Start () {
        isSeen = false;

		
	}
    public void SetTarget(Vector3 newtarget)
    {
        print(newtarget);
        print(transform.localPosition);
        normalizeDirection = (newtarget - transform.localPosition).normalized;
        normalizeDirection = new Vector3(normalizeDirection.x, normalizeDirection.y, 0f);
        //print(normalizeDirection);
    }


    public void SetTheTarget(Vector3 newtarget)
    {
        normalizeDirection = newtarget;
        speed = 0.1f;
    }


    public void SetType(string newtype)
    {
        type = newtype;
    }
	
	// Update: Movement & Kill logic
	void Update () {

        transform.position += normalizeDirection * speed * Time.deltaTime;

        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main))
        {
            isSeen = true;
        }


        if (RendererExtensions.IsVisibleFrom(this.GetComponent<RectTransform>(), Camera.main) == false && isSeen == true)
        {
            Destroy(this.gameObject);
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "playerplayer")
        {
            collision.gameObject.GetComponent<playerplayer>().kill();
        }
    }

}
