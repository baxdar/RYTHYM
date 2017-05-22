using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Rigidbody2D rigid;
    public int jumpHeight = 10;
    public GameObject swipe;

    public float speedMod = 10f;
    public int swipeOffsetX;
    public int swipeOffsetY;

    void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if (Input.GetButtonDown("Jump"))
            {
            Debug.Log("Should be Jumping");
            rigid.AddForce(new Vector3(0f, jumpHeight * 10000, 0f) * Time.deltaTime);
            }
        float moveX = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveX * (speedMod * 100) * Time.deltaTime, rigid.velocity.y);
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(swipe, new Vector3
                (transform.position.x + swipeOffsetX, transform.position.y + swipeOffsetY, 10f), Quaternion.identity);
        }
    }
}
