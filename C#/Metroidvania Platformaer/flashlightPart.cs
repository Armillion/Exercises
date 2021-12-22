using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flashlight", menuName = "FlashlightPart")]
public class flashlightPart : partPattern
{

    public flashlightPart()
    {
        partSerialNr = 5;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").transform.Find("Point Light 2D").gameObject.SetActive(true);
    }

    public override void onUnequip()
    {
        GameObject.FindWithTag("Player").transform.Find("Point Light 2D").gameObject.SetActive(false);
    }
}
