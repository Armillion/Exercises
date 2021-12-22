using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WallJump", menuName = "WallJumpPart")]
public class WallJumpPart : partPattern
{
    public WallJumpPart()
    {
        partSerialNr = 2;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").transform.Find("rightWallCheck").gameObject.SetActive(true);
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").transform.Find("rightWallCheck").gameObject.SetActive(false);
    }
}
