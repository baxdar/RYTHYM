using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public delegate void OnAttacking();
    public OnAttacking onAttacking;

    protected int hp;
    public int HP {
        get { return hp; }
        //set { if (value - hp < 0)
        //        //DoThis();
        //}
    }

    protected float speed;
    protected float jumpheight;
    protected float forcemult = 1000;
    protected float movement;
    protected Rigidbody2D charRigidBody;

    public void TakeDamage(int damage) {

    }

    public abstract void Attack();
}
