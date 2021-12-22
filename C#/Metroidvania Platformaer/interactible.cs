using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactible : MonoBehaviour
{
    public GameObject element;

    //a base for other scripts
    //if player stands inside trigger and presses a button something happens
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetButtonDown("Interact"))
        {
            element.SetActive(true);
        }
    }
}
