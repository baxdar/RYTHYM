using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {
    protected float speed;
    protected float jumpheight;
    protected float movement;
    protected Rigidbody2D eRigidBody;

    public delegate void OnAttacking();
    public OnAttacking onAttacking;

    protected int hp;
    public int HP {
        get { return hp; }
        set {
            hp -= value;
            if (hp <= 0)
                Die();
        }
    }

    public void TakeDamage(int damage) {
        HP -= damage;
    }

    public abstract void Die();

    public abstract void Attack();
}
