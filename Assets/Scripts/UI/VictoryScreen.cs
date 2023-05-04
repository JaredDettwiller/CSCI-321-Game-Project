using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    public GameObject VictoryPanel;

    /**
     * To open the victory panel, you just need to call
     * this function which will activate the function.  The click
     * button will quit the game.
     */
    public void openVictoryPanel()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0;
    }

    /**
     * For the on click
     */
    public void quitGameFromVictory()
    {
        Application.Quit();
    }
}
