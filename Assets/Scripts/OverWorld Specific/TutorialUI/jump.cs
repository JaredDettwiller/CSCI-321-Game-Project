using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
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
            textController.setUIText("Press space to jump.");
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
