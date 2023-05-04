using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    private float timeScale;
    private bool isPaused = false;
    //GameObject player;
    //MouseLook script;
    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<GameObject>();
        //script = player.GetComponent<MouseLook>();
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused && Time.timeScale != 0)
            {
                print(timeScale);
                timeScale = Time.timeScale;
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
                //script.enabled = false;
            }
            else if (isPaused)
            {
                print(timeScale);
                Time.timeScale = timeScale;
                isPaused = false;
                pausePanel.SetActive(false);
                //script.enabled = true;
            }
        }
    }

    public void clickResume()
    {
        Time.timeScale = timeScale;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void quitGame()
    {
        // Application.Quit won't work in game mode
        // If we want to be able to use the quit button
        // during development, we would use UnityEditor.EditorApplication.isPlaying = false;

        // We use Application.Quit() in the production code
        Application.Quit();
    }
}
