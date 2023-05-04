using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public PlayerProgressionController playerProgressionController;
    private int lastPlayerXPChecked;

    private void Start()
    {
        lastPlayerXPChecked = -1;
    }

    private void Update()
    {
        if(lastPlayerXPChecked != playerProgressionController.getPlayerCurrentExperiencePoints())
        {
            // Update level text
            Text levelText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            levelText.text = "Level: " + this.playerProgressionController.getCurrentLevelNumber();

            // Update the till next level text
            Text tillNextLevelText = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
            tillNextLevelText.text = "Till next level: " + this.playerProgressionController.getTillNextLevel() + "XP";

        }
    }
}
