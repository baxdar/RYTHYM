using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillEnemy : MonoBehaviour {

    private Animator anim;
    public bool detectingPlayer;

	void Awake () {
        anim = GetComponent<Animator>();
	}
    void Start()
    {
        anim.SetBool("idle", true);
    }
    private void Update()
    {
        detectingPlayer = Physics2D.OverlapBox(transform.position, new Vector2(4f, 1f), 0f);
    }
    IEnumerator DrillDown()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("idle", false);
        anim.SetBool("drillingDown", true);
    }
}
