using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : MonoBehaviour {
    public float speed = 8;
    public float jumpheight = 9;
    private Vector3 movement;
    private Rigidbody2D charRigidBody;
    private bool tryJump;

    private bool isGrounded() {
        Vector2 temprayorigin = transform.position;
        temprayorigin.y -= transform.lossyScale.y;
        return !Physics2D.Raycast(temprayorigin, Vector2.down, .1f);
    }

	void Start () {
        charRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        movement.x = Input.GetAxis("Horizontal") * speed;
        Debug.DrawRay(transform.position - new Vector3(0, transform.lossyScale.y / 2, 0), Vector2.down);
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            tryJump = true;
            Debug.Log("read jump");
        }
        if (Input.GetButtonDown("Fire1"))
            Debug.Log(movement + " : " + isGrounded());
	}

    void FixedUpdate() {
        if (tryJump && isGrounded()) {
            movement.y += jumpheight;
            Debug.Log("trying to jump");
        }
        else if (!isGrounded()) {
            tryJump = false;
            movement += Physics.gravity;
        }
        else
            movement.y = 0;
        charRigidBody.MovePosition(transform.position + movement * Time.deltaTime);
        transform.rotation = new Quaternion();
    }
}
