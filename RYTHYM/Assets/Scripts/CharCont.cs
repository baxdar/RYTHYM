using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour {
    public float speed = 8;
    public float jumpheight = 9;
    private Vector3 movement;
    private Rigidbody2D charRigidBody;
    public bool tryJump;
	// Use this for initialization
    private bool isGrounded() {
        return Physics2D.Raycast(transform.position, Vector2.down, .1f);
    }

	void Start () {
        charRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movement.x = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
            tryJump = true;
	}

    void FixedUpdate() {
        if (tryJump && isGrounded())
            movement.y += jumpheight;
        else
            movement += Physics.gravity * Time.fixedDeltaTime;
        charRigidBody.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        transform.rotation = new Quaternion();
    }
}
