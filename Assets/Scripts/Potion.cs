using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private float timeAlive;
    private float timeTillPickup;

    private void Start()
    {
        timeAlive = 0f;
        timeTillPickup = 1f;
    }

    private void Update()
    {
        if(timeAlive < timeTillPickup)
            timeAlive += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (timeAlive >= timeTillPickup)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                // Pick up the prefab into the players inventory
                Inventory receivingPlayerInventory = other.gameObject.GetComponent<Inventory>();
                pickUpPotion(receivingPlayerInventory);
            }
        }
    }

    private void pickUpPotion(Inventory playerInventory)
    {
        playerInventory.numberOfPotions += 1;
        Destroy(gameObject);
    }
}
