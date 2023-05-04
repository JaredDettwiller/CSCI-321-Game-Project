using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
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
            textController.setUIText("There's an enemy ahead! Try some of your new moves.");
            if(beenHere == false){
                TC.incrementTasksCompleted();
            }
            beenHere = true;
            TC.setSpawn("Tutorial Spawn 1");
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            textController.clearUI();
        }
    }
}
