using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythymKeeper : MonoBehaviour {

    public static RythymKeeper Instance;

    public bool onBeat;

    public IEnumerator rythym(int bpm, float offbeatMargin = 1 / 16) {
        float beatDuration = 60f / bpm;
        float nonEmpoweredInterval = beatDuration - 2 * offbeatMargin;
        onBeat = true;
        while (true) {
            //things that happen on the downbeat (met, GUI, etc.)
            Debug.Log("downbeat");
            yield return new WaitForSeconds(offbeatMargin);
            //things that happen when player isn't on tempo
            onBeat = false;
            Debug.Log(onBeat);
            yield return new WaitForSeconds(nonEmpoweredInterval);
            //things that happen when player is on tempo
            onBeat = true;
            Debug.Log(onBeat);
            yield return new WaitForSeconds(offbeatMargin);
        }
    }

    void Awake() {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
