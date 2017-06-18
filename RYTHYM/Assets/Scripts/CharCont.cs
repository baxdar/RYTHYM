using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCont : Entity {
    private bool tryJump;
    private float swipeOffsetX = 1.5f;
    private float swipeOffsetY = 0;
    public GameObject swipe;
    public GameObject empoweredswipe;
    private int screenWidth;
    private bool facingLeft;
    private Animator anim;

    private bool isGrounded() {
        Vector2 temprayorigin = transform.position;
        temprayorigin.y -= transform.lossyScale.y/2f;
        temprayorigin.y -= .001f;

        if (Physics2D.Raycast(temprayorigin, Vector2.down, .1f).collider != null) {
            return true;
        }
        return false;
    }

    public override void Attack() {
        anim.SetBool("attacking", true);
        if (RythymKeeper.RKInstance.OnBeat)
            Instantiate(empoweredswipe, new Vector3(transform.position.x + swipeOffsetX, transform.position.y + swipeOffsetY, 10f),
            Quaternion.identity);
        else {
            Instantiate(swipe, new Vector3(transform.position.x + swipeOffsetX, transform.position.y + swipeOffsetY, 10f),
            Quaternion.identity);
        }
        StartCoroutine(WaitForEndOfAttack());
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector2 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public override void Die() {
        Debug.Log("Death not yet implemented");
    }

    private void look(int width, int loc) {
        //if (loc < width)

    }

    IEnumerator WaitForEndOfAttack()
    {
        yield return new WaitForSeconds(.2f);
        anim.SetBool("attacking", false);
    }

    void Start () {
        screenWidth = Screen.width;
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 10;
        jumpheight = 20;
        hp = 10;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(Screen.height);
        movement = Input.GetAxis("Horizontal");
        if (Mathf.Abs(movement) > 0)
        {
            anim.SetFloat("speed", Mathf.Abs(movement));
        }
        anim.SetBool("grounded", isGrounded());
        if (Input.GetButton("Jump") && isGrounded()) {
            tryJump = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (movement < 0 && !facingLeft)
        {
            Flip();
        }
        if (movement > 0 && facingLeft)
        {
            Flip();
        }
    }

    void FixedUpdate() {
        if (tryJump && isGrounded()) {
            eRigidBody.velocity = new Vector2(eRigidBody.velocity.x, jumpheight);
            tryJump = false;
        }
        eRigidBody.velocity = new Vector2 (movement * speed, eRigidBody.velocity.y);
    }
}