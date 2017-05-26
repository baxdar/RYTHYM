using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour {
    public float speed = 8;
    public float jumpheight = 10;
    public float forcemult = 1000;
    private float movement;
    private Rigidbody2D charRigidBody;
    private bool tryJump;

    private bool isGrounded() {
        Vector2 temprayorigin = transform.position;
        temprayorigin.y -= transform.lossyScale.y/2f;
        temprayorigin.y -= .001f;

        if (Physics2D.Raycast(temprayorigin, Vector2.down, .1f).collider != null) {
            return true; }
        return false;
    }

	void Start () {
        charRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            tryJump = true;
        }
        //if (Input.GetButtonDown("Fire1")
        if (Input.GetButtonDown("Fire2"))
            Debug.Log(isGrounded());
	}

    void FixedUpdate() {
        if (tryJump && isGrounded()) {
            if (RythymKeeper.Instance.OnBeat)
                charRigidBody.AddForce(new Vector2(0, jumpheight * 150));
            else
                charRigidBody.AddForce(new Vector2(0, jumpheight * 100));
        }
        else if (!isGrounded()) {
            tryJump = false;
        }
        charRigidBody.velocity = new Vector2 (movement * speed * forcemult* Time.deltaTime, charRigidBody.velocity.y);
        transform.rotation = new Quaternion();
    }
}