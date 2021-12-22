using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int pickUpType = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Stats statystyki = collision.gameObject.GetComponent<Stats>();
            spellSystem system = collision.gameObject.GetComponent<spellSystem>();
            switch (pickUpType)
            {
                case 0:
                    statystyki.score += 10;
                    break;
                case 1:
                    statystyki.score += 5;
                    system.firstSpellUnlocked = true;
                    break;
                case 2:
                    statystyki.score += 5;
                    system.secondSpellUnlocked = true;
                    break;
                case 3:
                    statystyki.score += 5;
                    system.thirdSpellUnlocked = true;
                    break;
                case 4:
                    statystyki.score += 5;
                    system.fourthSpellUnlocked = true;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
