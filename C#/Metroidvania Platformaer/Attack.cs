using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public attackColision rightAtk;

    Stats statystyki;

    public float attackTime = 0.5f;
    public float attackDelay = 0.1f;

    float timer = 0;

    public bool attackVertical = false;
    
    //SpriteRenderer render;
  
    // Start is called before the first frame update
    void Start()
    {
        statystyki = GetComponent<Stats>();
        rightAtk.Statystyki = statystyki;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("AttackRight") && timer >= attackDelay + attackTime)
        {
            rightAtk.canAtk = true;
            rightAtk.isAttacking = true;
            timer = 0f;
            
            rightAtk.playAnimation();
            //render.sprite = movement.attackAnims[3];
            //movement.animationTimer = 0f;
        }

        if (rightAtk.isAttacking && timer >= attackTime)
        {
            rightAtk.canAtk = false;
            rightAtk.isAttacking = false;
        }
    }
}
