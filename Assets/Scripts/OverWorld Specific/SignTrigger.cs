using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    private UITextSet textController;
    private bool beenHere = false;
    private TutorialController TC;
    void Start()
    {
        textController = GameObject.Find("PanelScript").GetComponent<UITextSet>();
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            textController.setUIText("The sign reads: \n (DANGER) Litch's Castle -->. Abandoned Mine <--");
            TC.setSpawn("Sign Spawn");
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            textController.clearUI();
        }
    }
}
