using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject informationPanel;
    public GameObject persist;
    private float timeScale;

    // Start is called before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    // Update is called once per frame

    public void ClickStart()
    {
        Time.timeScale = timeScale;
        persist.SetActive(true);
        GameObject.Find("SceneController").GetComponent<SceneController>().startGame();
    }

    public void ClickInformation()
    {
        informationPanel.SetActive(true);
    }

    public void ExitInformation()
    {
        informationPanel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
