using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTest : MonoBehaviour {

    SpriteRenderer head;
	// Use this for initialization
	void Start () {
        head = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (RythymKeeper.RKInstance.OnBeat) {
            head.enabled = true;
            //Debug.Log("ON");
        }
        else {
            head.enabled = false;
            //Debug.Log("Off");

        }
    }
}
