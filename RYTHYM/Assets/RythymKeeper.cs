using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythymKeeper : MonoBehaviour {

    public IEnumerator rythym(int bpm, float offbeatMargin = 1 / 16) {
        float beatDuration = bpm / 60f;
        float nonEmpoweredInterval = beatDuration - 2 * offbeatMargin;

        while (true) {
            yield return new WaitForSeconds(offbeatMargin);

            yield return new WaitForSeconds(nonEmpoweredInterval);

            yield return new WaitForSeconds(offbeatMargin);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
