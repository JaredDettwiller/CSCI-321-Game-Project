using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    /**
     * This script will be connected to the HeartPanel, so we just
     * ass the game object as a child as the current (this) game object.
     */

    public PlayerCombatController PCC;
    public GameObject redHeartPrefab;
    public GameObject halfHeartPrefab;
    public GameObject blackHeartPrefab;
    private float numberOfHeartsInPanel;
    private float lastHealthChecked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastHealthChecked != PCC.getPlayerHealth())
        {
            updateHealthBar();
        }
    }

    void updateHealthBar()
    {
        float numberOfHearts;
        float numberOfRedHearts;
        // For now, make a heart be 10 health on the player
        int healthPerHeart = 10;

        //check if there is remainder
        if (PCC.getMaxHealth() % healthPerHeart != 0)
        {
            print("There is a remainder!");
            throw new System.Exception("There is a remainder in updateHealthBar! Remainder: " + PCC.getPlayerHealth() % healthPerHeart);
        }

        // Get information needed
        numberOfHearts = PCC.getMaxHealth() / healthPerHeart;
        numberOfRedHearts = PCC.getPlayerHealth() / healthPerHeart;

        // Clear hearts so we can add new hearts
        for(int i = 0; i < numberOfHeartsInPanel; i++)
        {
            GameObject go = gameObject.transform.GetChild(i).gameObject;
            Destroy(go);
        }

        // First put all the red hearts and then finish off the rest of the hearts
        int numberOfPrintedHearts = 0;

        while(numberOfPrintedHearts < numberOfHearts)
        {
            // Update the heart panel
            if(numberOfPrintedHearts < numberOfRedHearts && (numberOfRedHearts - numberOfPrintedHearts >= 1))
            {
                // Print a red heart
                GameObject redHeart =  (GameObject)Instantiate(redHeartPrefab);

                redHeart.transform.parent = gameObject.transform;
            }
            else if(numberOfPrintedHearts < numberOfRedHearts)
            {
                // Print a half heart
                GameObject halfHeart = (GameObject)Instantiate(halfHeartPrefab);

                halfHeart.transform.parent = gameObject.transform;
            }
            else
            {
                // Print a black heart
                GameObject blackHeart = (GameObject)Instantiate(blackHeartPrefab);

                blackHeart.transform.parent = gameObject.transform;
            }
            numberOfPrintedHearts++;
            
        }

        this.numberOfHeartsInPanel = numberOfPrintedHearts;
        this.lastHealthChecked = PCC.getPlayerHealth();
    }
}
