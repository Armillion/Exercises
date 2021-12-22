﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackColision : MonoBehaviour
{
    public Stats Statystyki;
    public bool canAtk = false;
    public bool isAttacking = false;
    public bool isPlayer = false;
    public float animationTime = 0.5f;
    float timer;

    public SpriteRenderer render;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= animationTime)
        {
            render.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.gameObject.GetComponent<Stats>()) != null && canAtk)
        {
            Stats staty = collision.gameObject.GetComponent<Stats>();
            staty.Health -= Statystyki.Atk;
            Vector2 vec = (transform.position - collision.transform.position) *-20;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(vec);
            if(!isPlayer)
            {
                //play animation
                playAnimation();
            }
            canAtk = false;
        }
    }

    public void playAnimation()
    {
        timer = 0f;
        render.enabled = true;
    }
}
