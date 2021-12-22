using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpComp : MonoBehaviour
{
    //TODO: fix spacebar spaming letting you climb

    Rigidbody2D rb;
    PlayerMovement movement;
    PlayerCntroller cntroller;
    HoverComponent hover;
    public bool isWallJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        hover = GameObject.FindWithTag("Player").GetComponent<HoverComponent>();
        isWallJumping = false;
    }

    private void Update()
    {
        if (!isWallJumping && rb.gravityScale != 1 && (hover == null || (hover != null && !hover.isGliding)))
        {
            rb.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && !movement.m_Grounded && (Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Horizontal") == 1))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Enemy" && !movement.m_Grounded && (Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Horizontal") == 1) && !Input.GetButton("Jump"))
        {
            rb.gravityScale = 0.1f;
            movement.nrJumps = 1;
            isWallJumping = true;
        }
        else
        {
            isWallJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isWallJumping = false;
    }
}
