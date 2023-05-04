using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The PlayerProgressionController class will keep track of the progression
 * of the user.  It will check when a player has killed an enemy,
 * and will also keep track of how much experience and what level the player
 * is on.
 * 
 * Notes for levels:
 * Max Level: 10
 */
public class PlayerProgressionController : MonoBehaviour
{
    public PlayerCombatController PCC;
    private int[] experienceForLevels;
    private int currentLevelNumber;
    private int playerCurrentExperiencePoints;
    private int maxLevel;

    private void Start()
    {
        currentLevelNumber = 1;
        playerCurrentExperiencePoints = 0;
        experienceForLevels = new int[] { 50, 120, 250, 400, 650, 1000 };
        maxLevel = experienceForLevels.Length + 1;
    }

    public int getTillNextLevel()
    {
        if (this.currentLevelNumber == this.maxLevel)
        {
            // Max Level
            return 0;
        }
        return this.experienceForLevels[this.currentLevelNumber - 1] - this.playerCurrentExperiencePoints;
    }

    public int getCurrentLevelNumber()
    {
        return this.currentLevelNumber;
    }

    public int getPlayerCurrentExperiencePoints()
    {
        return this.playerCurrentExperiencePoints;
    }

    public void addToPlayerExperiencePoints(int xpToAdd)
    {
        this.playerCurrentExperiencePoints += xpToAdd;

        // We should only need to check if the player leveled up after
        // adding to the player experience points

        print(this.playerCurrentExperiencePoints);

        this.checkLevelUp();
    }

    private void checkLevelUp()
    {
        if (this.currentLevelNumber == this.maxLevel)
        {
            // Max Level
            return;
        }
        for (int i = this.currentLevelNumber-1; i < this.experienceForLevels.Length; i++)
        {
            if (this.experienceForLevels[i] > this.playerCurrentExperiencePoints)
            {
                // If the player hasn't leveled up
                return;
            }
            print("Level up!");
            this.levelUp();
        }
    }

    /**
     * This function should be called every time the player levels up 
     */
    private void levelUp()
    {
        this.currentLevelNumber += 1;

        // Make changes for health and player damage multiplier
        this.PCC.addMaxHealth(10);
        this.PCC.setPlayerHealthToMax();
        this.PCC.damageMultiplier += 0.25f;

    }
}
