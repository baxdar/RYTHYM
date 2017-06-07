using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity {
    public abstract override void Attack();

    public abstract override void Die();

    public abstract bool DetectPlayer();

    public abstract void Patrol();

    public abstract void MoveToPlayer();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
