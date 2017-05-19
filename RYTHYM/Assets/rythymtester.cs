using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rythymtester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(RythymKeeper.Instance.rythym(120));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
