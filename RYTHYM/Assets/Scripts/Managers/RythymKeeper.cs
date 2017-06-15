using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythymKeeper : MonoBehaviour {

    public static RythymKeeper RKInstance;
    public AudioClip test;

    private bool onBeat;
    private bool upBeat;

    public bool OnBeat {
        get {
            return onBeat;
        }
    }

    public bool UpBeat {
        get {
            return upBeat;
        }
    }

    public IEnumerator rythym(int bpm, float offbeatMargin = 0.25f)
        {
        //since this coroutine deals with individual beats
        //offbeat margin is multiplied by a quarter note
        //1/8 * 1/2 = 1/32 by default
        //I could write a whole paragraph on how the math syncs up wth timing
        
        float beatDuration = 60f / bpm; // how long, in seconds, a beat lasts (eg 120 bpm - .5s beatduration)
        float eighthnote = beatDuration / 2;
        float onbeattiming = (beatDuration * offbeatMargin)/2;
        float eighthspacer = eighthnote - onbeattiming;
        onBeat = true;
        upBeat = false;
        while (true) {
            //things that happen on the downbeat 
            //Debug.Log("downbeat");
            upBeat = false;
            yield return new WaitForSeconds(onbeattiming);
            //things that happen when player isn't on tempo
            onBeat = false;
            //Debug.Log(onBeat);
            yield return new WaitForSeconds(eighthspacer);
            upBeat = true;
            //things that happen in the middle of the beat.  Enemy Attacks etc.
            yield return new WaitForSeconds(eighthspacer);
            //things that happen when player is on tempo
            onBeat = true;
            //Debug.Log(onBeat);
            yield return new WaitForSeconds(onbeattiming);
        }
    }

    void Awake() {
        RKInstance = this;

    }
}
