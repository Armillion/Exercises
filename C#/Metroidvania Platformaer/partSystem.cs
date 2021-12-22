using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partSystem : MonoBehaviour
{
    public List<partPattern> Parts;                                         //this is where you keep all parts you found
    //TODO: sprites nad animations
    public List<partPattern> equippedParts = new List<partPattern>();       //this is where you keep equipped parts
    public int maxEquippedParts = 4;                                        //this sets a max number of parts a player can equip at a time
    public List<GameObject> eq;                                             //buttons that equip and unequip parts

    public Text partUI;                                                     //displays nr of equipped parts / maxEquippedParts

    private void Start()
    {
        partUI.text = "Parts mounted: 0/" + maxEquippedParts.ToString();
    }

    //this functon handles finding new parts, it is to be run from the gameobject of part itself
    public void onPartPickUp(partPattern part)
    {
        //add part to our inventory
        Parts.Add(part);
        //set button for that part to active
        eq[part.partSerialNr].SetActive(true);
    }

    //this function hadles inventory screen, as well as equiping and unequiping parts
    public void buttonHandler(int partNr)
    {
        partPattern curPart = null;
        //chck what part are we refering to via its nr
        foreach (partPattern part in Parts)
        {
            if(part.partSerialNr == partNr)
            {
                curPart = part;
                break;
            }
        }

        if (curPart == null)
            return;

        //for set part equip it if it can be equipped
        //or unequip it if it cant
        foreach(partPattern part in equippedParts)
        {
            if(part == curPart)
            {
                equippedParts.Remove(part);
                part.onUnequip();
                partUI.text = "Parts mounted: " + equippedParts.Count.ToString() + "/" + maxEquippedParts.ToString();
                return;
            }
        }

        if(equippedParts.Count < 4)
        {
            equippedParts.Add(curPart);
            partUI.text = "Parts mounted: " + equippedParts.Count.ToString() + "/" + maxEquippedParts.ToString();
            curPart.onEquip();
        }
    }
}
