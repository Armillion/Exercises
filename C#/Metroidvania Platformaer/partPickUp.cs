using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partPickUp : MonoBehaviour
{
    public partPattern pert;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<partSystem>().onPartPickUp(pert);
            Destroy(gameObject);
        }
    }
}
