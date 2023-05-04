using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameObject gameOverPanel;
    private float timeWaiting;
    private float timeToWait;
    private bool playerIsDead;
    private PlayerCombatController PCC;

    public void Start()
    {
        gameOverPanel.SetActive(false);
        timeWaiting = 0;
        timeToWait = 2f;
        PCC = GameObject.Find("Player").GetComponent<PlayerCombatController>();
    }

    public void Update()
    {
        if(this.timeWaiting >= this.timeToWait && playerIsDead)
        {
            openGameOverPanel();
        }
        this.timeWaiting += Time.deltaTime;
    }

    public void startGameOverProcess()
    {
        this.timeWaiting = 0;
        this.playerIsDead = true;
    }

    // Game over entrance condition
    private void openGameOverPanel()
    {
        //Wait a few seconds before opening the game over panel
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    // Game over exit condition
    public void clickButton()
    {
        // Close game over panel and start the game
        SceneController sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        // Heal player to full
        PlayerCombatController player = GameObject.Find("Player").GetComponent<PlayerCombatController>();
        player.setPlayerHealthToMax();

        sceneController.respawnPlayerInScene();


        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        this.playerIsDead = false;
        PCC.Revive();
    }

}
