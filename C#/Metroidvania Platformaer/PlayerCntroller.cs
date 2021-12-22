using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntroller : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public float runSpeed = 40f;

    float horizontal = 0f;
    public bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        playerMovement.Move(horizontal * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
