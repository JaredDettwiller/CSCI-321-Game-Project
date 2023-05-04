using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerCombatController PCC;
    public bool hasKey;
    public int numberOfPotions;
    public int numberOfFairies;
    public int goldKeys;

    private float potionHealth;

    void Start()
    {
        hasKey = false;
        potionHealth = 20f;
        numberOfPotions = 0;
        numberOfFairies = 0;
        goldKeys = 0;
    }

    public bool usePotion()
    {
        if(numberOfPotions <= 0)
        {
            // No potions!
            return false;
        }
        if (!PCC.healPlayerByHealth(potionHealth)) {
            // Can't use potion!
            return false;
        }
        numberOfPotions--;
        return true;
    }

    public bool useFairy()
    {
        if(numberOfFairies <= 0)
        {
            // No fairies!
            return false;
        }
        numberOfFairies--;

        // Play sound effect
        GameObject soundEffects = GameObject.Find("SoundEffects");
        soundEffects.GetComponent<SoundEffects>().playFairySound();
        
        return true;
    }
    
    public void pickUpPotion(){
        numberOfPotions++;
    }
}
