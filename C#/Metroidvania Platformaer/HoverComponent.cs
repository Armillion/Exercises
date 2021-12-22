using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverComponent : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMovement movement;
    public bool isGliding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !movement.m_Grounded && movement.nrJumps == 0)
        {
            rb.gravityScale = 0.2f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            isGliding = true;
        }
        else if(movement.m_Grounded) 
        {
            rb.gravityScale = 1f;
            isGliding = false;
        }
    }
}
