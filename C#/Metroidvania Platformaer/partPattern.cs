using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partPattern : ScriptableObject
{
    //this is and base class, to be overriden when creating new parts

    //responsible for being some sort of ID
    //linking the part itself with button equiping it
    public int partSerialNr;
    public virtual void onEquip()
    {

    }

    public virtual void onUnequip()
    {

    }
}
