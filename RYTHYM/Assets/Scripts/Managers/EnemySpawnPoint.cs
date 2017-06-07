using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {
    public GameObject EnemyToSpawn;

    public void spawnEnemy() {
        Instantiate(EnemyToSpawn, transform.position, Quaternion.identity);
    }

	void Start () {
        EntityManager.EMInstance.SpawnEnemies += spawnEnemy;
	}
}
