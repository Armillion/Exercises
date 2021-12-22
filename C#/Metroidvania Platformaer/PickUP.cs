using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public int pickUpType = 0;
    public int amount = 1;

    //a simple function: if player touches this object, give them
    //appropriate item, play the effect and destroy itself
    //Pick up type 0 - money
    //Type 1 - batteries
    //type 2 - Omnitools
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            switch(pickUpType)
            {
                case 0:
                    collision.gameObject.GetComponent<Stats>().moneyPickUp(amount);
                    Destroy(gameObject);
                    break;
                case 1:
                    collision.gameObject.GetComponent<Stats>().batteryPickUp(amount);
                    Destroy(gameObject);
                    break;
                case 2:
                    collision.gameObject.GetComponent<Stats>().toolPickUp(amount);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
