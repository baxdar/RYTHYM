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
    public LayerMask groundMask;
    private BoxCollider2D hitbox;

    private bool isGrounded() {
        Vector2 temporigin = transform.position;
        temporigin.y -= hitbox.size.y/2f;
        Vector2 tempsize = new Vector2(hitbox.size.x, .1f);
   
        if (Physics2D.BoxCast(
            temporigin, tempsize, 90f, Vector2.down, groundMask).collider != null) {
            return true;
        }
        return false;
    }

    public override void Attack() {
        anim.SetBool("attacking", true);
        if (RythymKeeper.RKInstance.OnBeat)
            Instantiate(empoweredswipe, new Vector3(transform.localPosition.x + swipeOffsetX, transform.position.y + swipeOffsetY, 10f),
            Quaternion.identity);
        else {
            Instantiate(swipe, new Vector3(transform.localPosition.x + swipeOffsetX, transform.position.y + swipeOffsetY, 10f),
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

    IEnumerator WaitForEndOfAttack()
    {
        yield return new WaitForSeconds(.2f);
        anim.SetBool("attacking", false);
    }

    void Start () {
        eRigidBody = GetComponent<Rigidbody2D>();
        speed = 10;
        jumpheight = 20;
        hp = 10;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        hitbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update () {
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