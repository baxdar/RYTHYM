using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {
    public GameObject EnemyToSpawn;

    public void spawnEnemy() {
        //instantiate gameobject at location 
        //too lazy atm
    }

	void Start () {
        EntityManager.EMInstance.SpawnEnemies += spawnEnemy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
