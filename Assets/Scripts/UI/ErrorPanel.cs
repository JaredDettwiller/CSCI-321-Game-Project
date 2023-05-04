using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorPanel : MonoBehaviour
{

    public GameObject errorPanel;
    private float timeSinceErrorUp;

    private void Start()
    {
        timeSinceErrorUp = 0f;
    }
    private void Update()
    {
        if (timeSinceErrorUp > 3f && errorPanel.activeSelf)
        {
            errorPanel.SetActive(false);
        }
        else if (errorPanel.activeSelf)
        {
            timeSinceErrorUp += Time.deltaTime;
        }
    }

    public void openErrorPanel()
    {
        errorPanel.SetActive(true);
        timeSinceErrorUp = 0f;
    }
}
