﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythymManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(RythymKeeper.RKInstance.rythym(120));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
