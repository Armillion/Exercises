using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "DashPart")]
public class dashPart : partPattern
{
    public dashPart()
    {
        partSerialNr = 6;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").GetComponent<dashing>().enabled = true;
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").GetComponent<dashing>().enabled = false;
    }
}
