using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public attackColision upAtk;
    public attackColision downAtk;
    public attackColision leftAtk;
    public attackColision rightAtk;

    Stats statystyki;

    public float attackTime = 0.5f;
    public float attackDelay = 0.1f;

    float timer = 0;

    playerMovement movement;
    float spd;

    SpriteRenderer render;
    


    // Start is called before the first frame update
    void Start()
    {
        statystyki = GetComponent<Stats>();
        movement = GetComponent<playerMovement>();
        render = movement.render;
        upAtk.Statystyki = statystyki;
        downAtk.Statystyki = statystyki;
        leftAtk.Statystyki = statystyki;
        rightAtk.Statystyki = statystyki;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButtonDown("AttackUpper") && timer >= attackDelay + attackTime)
        {
            upAtk.canAtk = true;
            upAtk.isAttacking = true;
            timer = 0f;
            spd = movement.playerSpeed;
            upAtk.playAnimation();
            render.sprite = movement.attackAnims[0];
            movement.animationTimer = 0f;
        }

        if (Input.GetButtonDown("AttackDown") && timer >= attackDelay + attackTime)
        {
            downAtk.canAtk = true;
            downAtk.isAttacking = true;
            timer = 0f;
            spd = movement.playerSpeed;
            
            downAtk.playAnimation();
            render.sprite = movement.attackAnims[1];
            movement.animationTimer = 0f;
        }

        if (Input.GetButtonDown("AttackLeft") && timer >= attackDelay + attackTime)
        {
            leftAtk.canAtk = true;
            leftAtk.isAttacking = true;
            timer = 0f;
            spd = movement.playerSpeed;
            
            leftAtk.playAnimation();
            render.sprite = movement.attackAnims[2];
            movement.animationTimer = 0f;
        }

        if (Input.GetButtonDown("AttackRight") && timer >= attackDelay + attackTime)
        {
            rightAtk.canAtk = true;
            rightAtk.isAttacking = true;
            timer = 0f;
            spd = movement.playerSpeed;
            
            rightAtk.playAnimation();
            render.sprite = movement.attackAnims[3];
            movement.animationTimer = 0f;
        }

        if (upAtk.isAttacking && timer >= attackTime)
        {
            upAtk.canAtk = false;
            upAtk.isAttacking = false;
            movement.playerSpeed = spd;
        }

        if (downAtk.isAttacking && timer >= attackTime)
        {
            downAtk.canAtk = false;
            downAtk.isAttacking = false;
            movement.playerSpeed = spd;
        }

        if (leftAtk.isAttacking && timer >= attackTime)
        {
            leftAtk.canAtk = false;
            leftAtk.isAttacking = false;
            movement.playerSpeed = spd;
        }

        if (rightAtk.isAttacking && timer >= attackTime)
        {
            rightAtk.canAtk = false;
            rightAtk.isAttacking = false;
            movement.playerSpeed = spd;
        }
    }
}
