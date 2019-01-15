using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmove : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 2.0f;
    public bool inGame;
    public bool movementLocked;



    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}



    public void lockMovement(bool isLocked)
    {
        movementLocked = isLocked;

    }

    public void Reset()
    {
        transform.position = new Vector3 (0f, 0f, -0.1f);
        rb.velocity = Vector2.zero ;
    }

    // Update is called once per frame
    void Update () {
        if (!movementLocked)
        {
            float movehorizontal = Input.GetAxis("Horizontal");
            float movevertical = Input.GetAxis("Vertical");

            Vector3 movedirection = new Vector2(movehorizontal, movevertical);

            rb.velocity = speed * movedirection;
        }




		
	}
}
