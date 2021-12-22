using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hover", menuName = "HoverPart")]
public class hoveringPart : partPattern
{
    //second part
    //allows player to glide slowly through the air
    HoverComponent component;

    public hoveringPart()
    {
        partSerialNr = 1;
    }

    public override void onEquip()
    {
        component = GameObject.FindWithTag("Player").AddComponent<HoverComponent>();
    }

    public override void onUnequip()
    {
        Destroy(component);
    }
}
