using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxTrigger : MonoBehaviour
{
    /**
     * This trigger script will allow a one block text to be displayed to the user for
     * a set amount of time.  After the set amount of time, the text box will dissapear from the
     * users view.  
     * This should be used to display messages to inform the user of something in the main gameplay.  Not for
     * main dialogue
     */
    public GameObject textPanel;
    private GameObject currentTextBox;
    private double textBoxTime;
    private double elapsedTime;

    public GameObject[] texts;

    private void Start()
    {
        textBoxTime = 5f;
        elapsedTime = 0;
    }
    private void Update()
    {
        // This should delete after some amount of time
        if(currentTextBox != null && elapsedTime > textBoxTime)
        {
            currentTextBox.SetActive(false);
            currentTextBox = null;
            textPanel.SetActive(false);
        }
        // Add to elapsed time
        elapsedTime += Time.deltaTime;
    }
    public void DisplayTextInPanel(string textName) 
    {
        foreach (GameObject textBox in texts)
        {
            if (textBox.name == textName)
            {
                if (currentTextBox != null)
                {
                    currentTextBox.SetActive(false);
                    currentTextBox = null;
                }
                currentTextBox = textBox;
                break;
            }
        }

        if (currentTextBox == null)
        {
            throw new System.Exception("textBox doesn't match anything!");
        }

        elapsedTime = 0;
        textPanel.SetActive(true);
        currentTextBox.SetActive(true);
    }
}
