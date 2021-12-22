using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sprint", menuName = "SprintPart")]
public class sprintPart : partPattern
{
    public sprintPart()
    {
        partSerialNr = 7;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").GetComponent<Sprint>().enabled = true;
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").GetComponent<Sprint>().enabled = false;
    }
}
