﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : Entity {
    private bool tryJump;
    
    private bool isGrounded() {
        Vector2 temprayorigin = transform.position;
        temprayorigin.y -= transform.lossyScale.y/2f;
        temprayorigin.y -= .001f;

        if (Physics2D.Raycast(temprayorigin, Vector2.down, .1f).collider != null) {
            return true; }
        return false;
    }

    public override void Attack() {
        Debug.Log("Not Implemented Yet");
    }

    public override void Die() {
        Debug.Log("Death not yet implemented");
    }

    void Start () {
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 6;
        jumpheight = 10;
        forcemult = 100;
    }

    // Update is called once per frame
    void Update () {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump") && isGrounded()) {
            tryJump = true;
        }
        if (Input.GetButtonDown("Fire1"))
            Attack();
        if (Input.GetButtonDown("Fire2"))
            Debug.Log(isGrounded());
	}

    void FixedUpdate() {
        if (tryJump && isGrounded()) {
            if (RythymKeeper.Instance.OnBeat)
                eRigidBody.AddForce(new Vector2(0, jumpheight * 150));
            else
                eRigidBody.AddForce(new Vector2(0, jumpheight * 100));
            tryJump = false;
        }
        eRigidBody.velocity = new Vector2 (movement * speed * forcemult* Time.deltaTime, eRigidBody.velocity.y);
        transform.rotation = new Quaternion();
    }

}