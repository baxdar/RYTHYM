using System;
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

    private void Start() {
        StartCoroutine(SpawnAllEnemies());
    }

    IEnumerator SpawnAllEnemies() {
        yield return null;
        SpawnEnemies();
    }
}
