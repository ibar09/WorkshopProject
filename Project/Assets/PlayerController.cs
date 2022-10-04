using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jump_speed;
    public Animator animator;
    public Transform topRight;
    public Transform bottomLeft;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isJumping", !onGround());
        if (Input.GetKeyDown(KeyCode.Space) && onGround())
        {
            Debug.Log("jumped");
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (Input.GetAxisRaw("Horizontal") != 0)
        { transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1); }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, rb.velocity.y);

    }
    public bool onGround()
    {
        return Physics2D.OverlapArea(topRight.position, bottomLeft.position, groundLayer);
    }
}
