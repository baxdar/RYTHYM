using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamConeEnemy : Enemy {
    public override void Attack() {
        throw new NotImplementedException();
    }

    public override bool DetectPlayer() {
        throw new NotImplementedException();
    }

    public override void Die() {
        throw new NotImplementedException();
    }

    public void Patrol() {
        
    }

    // Use this for initialization
    void Start () {
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 8;
        jumpheight = 0;
        HP = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
