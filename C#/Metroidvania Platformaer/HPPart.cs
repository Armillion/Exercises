using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HPUp", menuName = "HPUpPart")]
public class HPPart : partPattern
{
    //this part provides a simple +2 max hp bonus
    public HPPart()
    {
        partSerialNr = 3;
    }

    public override void onEquip()
    {
        GameObject.FindWithTag("Player").GetComponent<Stats>().Health += 4;
        GameObject.FindWithTag("Player").GetComponent<Stats>().MaxHealth += 4;
    }

    public override void onUnequip()
    {
        if(GameObject.FindWithTag("Player").GetComponent<Stats>().Health > 4)
            GameObject.FindWithTag("Player").GetComponent<Stats>().Health -= 4;

        GameObject.FindWithTag("Player").GetComponent<Stats>().MaxHealth -= 4;
    }
}
