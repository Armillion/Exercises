using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed = 4f;
    private Rigidbody2D rb;
    private Stats statystyki;
    int predkosc;

    public SpriteRenderer render;
    public List<Sprite> movingAnims_Right;
    public List<Sprite> movingAnims_Left;
    public List<Sprite> attackAnims;
    public Sprite idelAnim;
    int currSprite = 0;
    public float animOffset = 0.2f;
    public float animationTimer = 0f;

    public Vector2 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        statystyki = GetComponent<Stats>();
        predkosc = statystyki.Spd;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        getInputs();
        animationTimer += Time.deltaTime;
        if(predkosc < statystyki.Spd)
        {
            if(statystyki.Spd < 10)
            playerSpeed += 0.5f * (float)(statystyki.Spd - predkosc);
            predkosc = statystyki.Spd;
        }

        if (dir != Vector2.zero && animationTimer >= animOffset && (dir.x > 0 || dir.y !=0))
        {
            render.sprite = movingAnims_Right[currSprite];
            currSprite++;
            if (currSprite >= movingAnims_Right.Count)
                currSprite = 0;

            animationTimer = 0f;
        }
        else if (dir != Vector2.zero && animationTimer >= animOffset && dir.x < 0)
        {
            render.sprite = movingAnims_Left[currSprite];
            currSprite++;
            if (currSprite >= movingAnims_Left.Count)
                currSprite = 0;

            animationTimer = 0f;
        }
        else if (dir == Vector2.zero && animationTimer >= animOffset)
        {
            render.sprite = idelAnim;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void getInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        dir = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(dir.x * playerSpeed, dir.y * playerSpeed);
    }


}
