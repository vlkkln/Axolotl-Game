using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private float moveSpeed;
    private float jumpForce;
    public bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    public float speed;
    public float jump;
    public Animator animator;


    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        jumpForce = 7.5f;
    }


    void Update()
    {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1) {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    void FixedUpdate()
    {        
        speed = rb2d.velocity.x;        
        jump = rb2d.velocity.y;
            if (moveHorizontal > 0f || moveHorizontal < 0f)
            {
                rb2d.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);            
            }
        if (!isJumping && moveVertical > 0f)
        {
            while (rb2d.velocity.y <= 25f) { rb2d.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse); }
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "ground")
            {
            isJumping = false;
            animator.SetBool("isjump", false);
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "ground")
            {
            isJumping = true;
            animator.SetBool("isjump", true);
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping = false;
            animator.SetBool("isjump", false);
        }
    }
}
