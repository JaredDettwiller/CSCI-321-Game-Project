using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoorHandler : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        if(player.GetComponent<Inventory>().hasKey && Input.GetKeyDown(KeyCode.E))
        {
            // Open the door
            Animator anim = GameObject.Find("Hinge").GetComponent<Animator>();
            anim.SetBool("doorIsOpen", true);
        }
        else if(!player.GetComponent<Inventory>().hasKey && Input.GetKeyDown(KeyCode.E)) 
        {
            // Tell the player that the door is locked.
            GameObject textObject = GameObject.Find("Textbox");
            textObject.GetComponent<TextboxTrigger>().DisplayTextInPanel("NoKeyDoorText");
        }
    }
}
