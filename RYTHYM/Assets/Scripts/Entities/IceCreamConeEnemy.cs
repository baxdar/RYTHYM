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

    public void Patrol() {
        
    }

    // Use this for initialization
    void Start () {
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 8;
        jumpheight = 0;
        hp = 2;
	}

    private void OnTriggerEnter(Collider other) {
           
    }

    // Update is called once per frame
    void Update () {
		
	}
}
