using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

    SpriteRenderer spriteRenderer;

	void Start () {
        Destroy(gameObject, .5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
    void Update()
    {
        spriteRenderer.material.color -= new Color(0f, 0f, 0f, .04f)* Time.deltaTime;
    }
}
