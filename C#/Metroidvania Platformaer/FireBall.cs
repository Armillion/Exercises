using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int dmg;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.GetComponent<Stats>()) != null)
        {
            collision.gameObject.GetComponent<Stats>().takeDmg(dmg);
        }
        Destroy(gameObject);
    }
}
