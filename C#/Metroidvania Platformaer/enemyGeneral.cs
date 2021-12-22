using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGeneral : MonoBehaviour
{
    Stats Statystyki;                       //stats of our enemy
    AIDestinationSetter destinationSetter;  //component storing location of our player              
    public float distance = 10f;            //distance from which player can be seen
    public bool isPatrolling = false;       //if enemy is patrolling then he ignores the player
    public bool attacksManually = false;    //if enemy attacks manyally then player doesn't get damaged by touching him
    bool hasSpottedPlayer = false;          //true if player has entered distance set before
    GameObject Player;                      //player object, added because it was often referenced

    public float knockbackForce = 500f;     //force applied to the player after hitting him

    //get our components
    void Start()
    {
        Statystyki = GetComponent<Stats>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        Player = GameObject.FindWithTag("Player");
    }

    //if you havent spotted player already and arent patrolling
    //and he entered your area
    //chase him
    void Update()
    {
        if (!isPatrolling && !hasSpottedPlayer)
        {
            if (Vector2.Distance(Player.transform.position, transform.position) <= distance)
            {
                hasSpottedPlayer = true;
                destinationSetter.target = Player.transform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            Stats staty = collision.gameObject.GetComponent<Stats>();
            staty.takeDmg(Statystyki.Atk);
            Vector2 vec = (transform.position - collision.transform.position) * -20;
            vec.x *= knockbackForce;
            vec.y *= knockbackForce / 4;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(vec);
        }
    }

}
