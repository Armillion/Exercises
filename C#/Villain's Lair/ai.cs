using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public int enemyType = 0;
    //0 - melee
    //1 - ranged
    Stats statystyki;
    GameObject gracz;

    //meele enemy
    public attackColision upAtk;
    public attackColision downAtk;
    public attackColision leftAtk;
    public attackColision rightAtk;
    bool canAttack = false;

    //ranged enemy
    public GameObject projectile;

    //other
    public float attackTime = 0.2f;
    public float attackDelay = 0.5f;
    public float attackPrep = 0.4f;

    float timer = 0f;
    float animationTimer = 0f;
    float enemySpeed = 4f;

    private Vector2 dir;
    public float minDist = 2f;
    Rigidbody2D rb;

    //for animations
    SpriteRenderer render;
    public List<Sprite> movingAnims_Right;
    public List<Sprite> movingAnims_Left;
    public List<Sprite> attackAnims;
    public Sprite idelAnim;
    int currSprite = 0;
    public float animOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        statystyki = GetComponent<Stats>();
        gracz = GameObject.FindWithTag("Player");
        upAtk.Statystyki = statystyki;
        downAtk.Statystyki = statystyki;
        leftAtk.Statystyki = statystyki;
        rightAtk.Statystyki = statystyki;
        enemySpeed += 0.5f * (statystyki.Spd - 5);
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        if(enemyType == 1)
        {
            timer = attackDelay + attackPrep + attackTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        calculatePositions();
        timer += Time.deltaTime;
        animationTimer += Time.deltaTime;
        if (gracz != null)
        {
            if (Vector2.Distance(transform.position, gracz.transform.position) <= minDist && timer >= attackDelay + attackPrep + attackTime)
            {
                Attack();
                timer = 0f;
            }
        }

        if(canAttack && timer >= attackPrep)
        {
            upAtk.canAtk = true;
            upAtk.isAttacking = true;
            downAtk.canAtk = true;
            downAtk.isAttacking = true;
            leftAtk.canAtk = true;
            leftAtk.isAttacking = true;
            rightAtk.canAtk = true;
            rightAtk.isAttacking = true;
            canAttack = false;
        }

        if (upAtk.isAttacking && !upAtk.canAtk)
        {
            render.sprite = attackAnims[0];
            animationTimer = animOffset - attackTime;
            dir = Vector2.zero;
        }
        else if (downAtk.isAttacking && !downAtk.canAtk)
        {
            render.sprite = attackAnims[1];
            animationTimer = animOffset - attackTime;
            dir = Vector2.zero;
        }
        else if (leftAtk.isAttacking && !leftAtk.canAtk)
        {
            render.sprite = attackAnims[2];
            animationTimer = animOffset - attackTime;
            dir = Vector2.zero;
        }
        else if (rightAtk.isAttacking && !rightAtk.canAtk)
        {
            render.sprite = attackAnims[3];
            animationTimer = animOffset - attackTime;
            dir = Vector2.zero;
        }
        

        if (((upAtk.isAttacking || downAtk.isAttacking || leftAtk.isAttacking || rightAtk.isAttacking) && (!upAtk.canAtk || !downAtk.canAtk || !leftAtk.canAtk || !rightAtk.canAtk)) || timer >= attackPrep+attackTime )
        {
            canAttack = false;
            upAtk.canAtk = false;
            upAtk.isAttacking = false;
            downAtk.canAtk = false;
            downAtk.isAttacking = false;
            leftAtk.canAtk = false;
            leftAtk.isAttacking = false;
            rightAtk.canAtk = false;
            rightAtk.isAttacking = false;
        }
        
        if(dir != Vector2.zero && animationTimer >= animOffset && (dir.x > 0 || dir.y != 0))
        {
            render.sprite = movingAnims_Right[currSprite];
            currSprite++;
            if (currSprite >= movingAnims_Right.Count)
                currSprite = 0;

            animationTimer = 0f;
        }
        else if(dir != Vector2.zero && animationTimer >= animOffset && dir.x < 0)
        {
            render.sprite = movingAnims_Left[currSprite];
            currSprite++;
            if (currSprite >= movingAnims_Left.Count)
                currSprite = 0;

            animationTimer = 0f;
        }
        else if(dir == Vector2.zero && animationTimer >= animOffset)
        {
            render.sprite = idelAnim;
        }
    }

    void calculatePositions()
    {
        if(gracz != null)
            dir = transform.position - gracz.transform.position;

        dir.x = Mathf.Clamp(dir.x, -1, 1);
        dir.y = Mathf.Clamp(dir.y, -1, 1);
        dir *= -1;
        if(enemyType == 1 && timer < attackDelay)
        {
            dir *= -1;
        }
        if(gracz != null)
        {
            if (Vector2.Distance(transform.position, gracz.transform.position) <= minDist && timer < attackPrep + attackTime)
            {
                dir = Vector2.zero;
            }
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(dir.x * enemySpeed, dir.y * enemySpeed);
    }

    void Attack()
    {
        if(enemyType == 0) //melee attack
        {
            canAttack = true;
        }
        else if(enemyType == 1) //ranged attack
        {
            GameObject proj = Instantiate(projectile,transform.position,Quaternion.identity);
            proj.GetComponent<projectileScript>().dmg = statystyki.Atk;
            if(dir.x > 0)
            {
                render.sprite = attackAnims[0];
                animationTimer = 0f;
            }
            else
            {
                render.sprite = attackAnims[1];
                animationTimer = 0f;
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
