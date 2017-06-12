using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
    private GameObject player;
    public delegate void spawnEnemies();
    public spawnEnemies SpawnEnemies;

    public static EntityManager EMInstance;
    private void Awake() {
        EMInstance = this;
    }

    private IEnumerator waittoSpawn() {
        yield return new WaitForSeconds(.25f);
        SpawnEnemies();
    }

    private void Start() {
        waittoSpawn();
    }
}
