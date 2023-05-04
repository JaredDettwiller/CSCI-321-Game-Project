using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    private UITextSet textController;
    private TutorialController TC;
    private bool beenHere = false;
    void Start()
    {
        textController = GameObject.Find("PanelScript").GetComponent<UITextSet>();
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            textController.setUIText("Approach the chest and press 'e' to open it.");
            if(beenHere == false){
                TC.incrementTasksCompleted();
            }
            beenHere = true;
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            textController.clearUI();
        }
    }
}
