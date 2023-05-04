using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPrompt : MonoBehaviour
{
    private UITextSet textController;
    private TutorialController TC;
    void Start()
    {
        textController = GameObject.Find("PanelScript").GetComponent<UITextSet>();
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
    }

    public void NotEnoughKeys()
    {
        textController.setUIText("There's four key slots in the door. You won't be able to get in unless you find all of them.");
    }

    public void LeftDoorArea()
    {
        textController.clearUI();
    }
}