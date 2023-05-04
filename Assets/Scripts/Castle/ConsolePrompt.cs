using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolePrompt : MonoBehaviour
{
    private UITextSet textController;
    private TutorialController TC;
    void Start()
    {
        textController = GameObject.Find("PanelScript").GetComponent<UITextSet>();
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
    }

    public void InRange()
    {
        textController.setUIText("Press the following keys to: \n1 - Rotate top row \n2 - Rotate middle row \n3 - Rotate bottom row");
    }

    public void OutOfRange()
    {
        textController.clearUI();
    }
}