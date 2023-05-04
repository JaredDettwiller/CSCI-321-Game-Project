using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Barrels should be able to drop items such as potions, hearts
 * if they should be allowed to.
 * 
 * Barrels will also be handled to drop keys
 */
public class BarrelItemHandler : MonoBehaviour
{
    public bool canDropHearts;
    public bool canDropPotion;
    public bool isKeyBarrel;
    private bool willDropItem;
    public GameObject potionPrefab;

    public bool getWillDropItem()
    {
        return this.willDropItem;
    }

    public void setWillDropItem(bool willDropItem)
    {
        this.willDropItem = willDropItem;
    }

    public void dropItem()
    {
        if(isKeyBarrel)
        {
            Inventory playerInv = GameObject.Find("Player").GetComponent<Inventory>();
            playerInv.hasKey = true;
            // Display to the user they got the key!
            GameObject textObject = GameObject.Find("Textbox");
            textObject.GetComponent<TextboxTrigger>().DisplayTextInPanel("PickedUpKeyText");
        }
        else if(this.canDropPotion)
        {
            GameObject droppedPotion = (GameObject)Instantiate(
                potionPrefab, 
                gameObject.transform.position,
                gameObject.transform.rotation);
        }
    }
    
    void Start()
    {
        if(canDropHearts && canDropPotion)
        {
            Destroy(this);
            throw new System.Exception("Error in Barrel!");
        }
        if (isKeyBarrel)
        {
            willDropItem = true;
            // A key barrel can't hold anything else in it
            if (canDropHearts || canDropPotion)
            {
                Destroy(this);
                throw new System.Exception("Error in Barrel!");
            }
        }

        else if (canDropHearts && !canDropPotion)
        {

        }
        else if (!canDropHearts && canDropPotion)
        {
            this.willDropItem = true;
        }
        else
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
