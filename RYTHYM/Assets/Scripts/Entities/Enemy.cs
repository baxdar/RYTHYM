using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity {
    protected bool foundPlayer = false;

    public abstract override void Attack();

    public override void Die() {
        //death anim goes here
        DestroyObject(gameObject);
    }

    public abstract bool DetectPlayer();


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
