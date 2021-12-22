using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public int dmg = 1;
    public float speed;
    public bool targetPlayer = true;
    float timer = 0f;

    public Vector2 dir;
    Rigidbody2D rb;
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(targetPlayer)
            dir = GameObject.FindWithTag("Player").transform.position - transform.position;
        rb.velocity = dir * speed;
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.9f)
        {
            box.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Stats>() != null && timer >= 0.9f)
        {
            Stats staty = collision.gameObject.GetComponent<Stats>();
            staty.Health -= dmg;
            //TODO: play sound
            Destroy(gameObject);
        }

        if (timer >= 0.9f)
            Destroy(gameObject);
    }

}
