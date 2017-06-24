using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamConeEnemy : Enemy {
    public LayerMask layermask;

    public override void Attack() {
        throw new NotImplementedException();
    }

    public override bool DetectPlayer() {
        return false;
    }

    private bool turnAround() {
        Collider2D wallcheck;
        Collider2D floorcheck;
        Vector2 castOrigin = new Vector2(transform.position.x - 2.4f, transform.position.y);
        wallcheck = Physics2D.BoxCast(castOrigin, new Vector2(.1f, 2), 0, 
            new Vector2(transform.localScale.x, 0), .1f, layermask).collider;
        floorcheck = Physics2D.Raycast(castOrigin, Vector2.down, 2.5f, layermask).collider;
        if (wallcheck != null || floorcheck == null)
            return true;
        return false;
    }

    public void Patrol() {
        eRigidBody.velocity = new Vector2(speed * movement, 0);
        if (turnAround()) {
            Vector2 newscale = transform.localScale;
            newscale.x *= -1;
            transform.localScale = newscale;
        }
    }

    public void Chase() {

    }

    void Start () {
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 4;
        jumpheight = 0;
        hp = 2;
        movement = -1;
	}

    private void OnTriggerEnter(Collider other) {
        //use for attack detection
    }

    void FixedUpdate() {
        if (!DetectPlayer())
            Patrol();
        else
            Chase();
    }
}
