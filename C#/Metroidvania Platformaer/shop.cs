using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : interactible
{
    //use of the interactible base
    //a shop where player can spend money to buy batteries and parts

    public List<partPattern> partsToSell;       //list of parts player can buy
    public List<int> prices;                    //prices of said parts
    public List<GameObject> buttons;            //buttons representing them in the world

    public int batteryPrice;                    //a price for 1 battery

    GameObject Player;                          //we are refering to the player himself many times so lets remember him

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    //if player has enough money for set part, remove it from the shop
    //and add it to player's inventory
    public void buyParts(int id)
    {
        if(Player.GetComponent<Stats>().money >= prices[id])
        {
            Player.GetComponent<Stats>().money -= prices[id];
            Player.GetComponent<partSystem>().onPartPickUp(partsToSell[id]);
            Destroy(buttons[id]);
        }
    }

    //same as before but without removing from stock
    public void buyBatteries()
    {
        if (Player.GetComponent<Stats>().money >= batteryPrice)
        {
            Player.GetComponent<Stats>().money -= batteryPrice;
            Player.GetComponent<Stats>().nrOfBatteries++;
        }
    }

    //allows the player to close shop UI
    public void exitShop()
    {
        element.SetActive(false);
    }
}
