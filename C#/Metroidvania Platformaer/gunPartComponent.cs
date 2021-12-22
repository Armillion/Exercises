using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPartComponent : MonoBehaviour
{
    public GameObject projectile;
    GameObject proj;
    Transform Player;
    Stats staty;
    Transform spawnPoint;

    public float attackSpeed = 0.1f;
    float timer = 0f;
    public float projectileSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        staty = Player.GetComponent<Stats>();
        spawnPoint = Player.Find("spawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButtonDown("AttackRight") && timer >= attackSpeed)
        {
            proj = Instantiate(projectile,spawnPoint.position,Quaternion.identity);
            proj.GetComponent<FireBall>().dmg = staty.Atk;
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Player.localScale.x*projectileSpeed,0f);
            timer = 0f;
        }
    }
}
