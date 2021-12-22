using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "doublejump", menuName = "DoubleJumpPart")]
public class doubleJumpPart : partPattern
{
    //first part to be found
    //simply gives double jump
    public doubleJumpPart()
    {
        partSerialNr = 0;
    }
    public override void onEquip()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().maxNrJumps = 1;
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().maxNrJumps = 0;
    }
}
