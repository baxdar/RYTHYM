using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity {

    private void Start() {
        
    }

    void Dodge() {

    }

    public override void Attack() {
    }

    public override void Die() {

    }
}

public class Weapon : MonoBehaviour {

    public Entity owner;

    private void Awake() {
        owner = GetComponentInChildren<Entity>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        // find out if on or up
        //IAttackable attackable = other.gameObject.Find();
        int damage = 0;
        if (RythymKeeper.RKInstance.OnBeat) {
            damage = 2;
        }
        else {
            damage = 1;
        }

        Entity entity = other.GetComponent<Entity>();
        if (entity != null) {
            entity.TakeDamage(damage);
        }
    }
}

public class Dump : MonoBehaviour {

    //Use this for initialization

   void Start () {

    }

    //Update is called once per frame

    void Update() {

    }
}
