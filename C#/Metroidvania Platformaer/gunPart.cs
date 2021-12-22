using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "GunPart")]
public class gunPart : partPattern
{
    public gunPart()
    {
        partSerialNr = 4;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").GetComponent<Attack>().enabled = false;
        GameObject.FindWithTag("Player").GetComponent<gunPartComponent>().enabled = true;
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").GetComponent<Attack>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<gunPartComponent>().enabled = false;
    }
}
