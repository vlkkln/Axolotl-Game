using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using TMPro;
using Steamworks;

public class CMMulti : NetworkBehaviour
{
    private Rigidbody2D rb2d;    

    private float moveSpeed = 2f;
    private float jumpForce = 7.5f;
    public bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    public float speed;
    public float jump;
    public Animator animator;
    public TextMeshProUGUI nickName;
    public static int playerid;

    public GameObject PlayerModel;

    private CustomNetworkManager manager;
    private CustomNetworkManager Manager
    {
        get
        {
            if (manager != null)
            {
                return manager;
            }
            return manager = CustomNetworkManager.singleton as CustomNetworkManager;
        }
    }

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        PlayerModel.SetActive(false);
    }


    void Update()
    {
        OnStopServer();
        if (SceneManager.GetActiveScene().name == "Game") {
            if (PlayerModel.activeSelf == false) {
                playerid = gameObject.transform.GetComponent<PlayerObjectController>().PlayerIdNumber;
                nickName.text = gameObject.transform.GetComponent<PlayerObjectController>().PlayerName;
                PlayerModel.SetActive(true);
                SetPosition();
            }                     
        }
        if (hasAuthority)
        {
            inputUpdate();
        }
    }

    void inputUpdate() {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animator.SetBool("facingRight", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            animator.SetBool("facingRight", true);
        }
    }

    void FixedUpdate()
    {
        if (hasAuthority)
        {
            rbFUpdate();
        }
    }

    void rbFUpdate() {
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
        if (hasAuthority)
        {
            if (collision.gameObject.tag == "ground")
            {
                isJumping = false;
                animator.SetBool("isjump", false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (hasAuthority)
        {
            if (collision.gameObject.tag == "ground")
            {
                isJumping = true;
                animator.SetBool("isjump", true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hasAuthority)
        {
            if (collision.gameObject.tag == "ground")
            {
                isJumping = false;
                animator.SetBool("isjump", false);
            }
        }
    }

    public void SetPosition()
    {
        rb2d.constraints = ~RigidbodyConstraints2D.FreezePositionX & ~RigidbodyConstraints2D.FreezePositionY;        
    }
}

