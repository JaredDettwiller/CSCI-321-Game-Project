using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Inventory player;
    public GameObject door;
    public bool isInteractable = false;
    public bool doorOpened = false;
    public Animator doorOpen;
    public AudioClip gateOpen;
    private DoorPrompt doorPrompt;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Inventory>();
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && doorOpened == false)
        {
            isInteractable = true;
            //if(player.playerHasKey == true)
            //{
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(player.goldKeys == 4)
                    {
                        doorOpen.SetTrigger("Open");
                        GetComponent<AudioSource>().PlayOneShot(gateOpen);
                        doorOpened = true;
                    }
                    else
                    {
                        GetComponent<DoorPrompt>().NotEnoughKeys();
                    }
                }
            //}
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isInteractable = false;
            GetComponent<DoorPrompt>().LeftDoorArea();
        }
    }
}
