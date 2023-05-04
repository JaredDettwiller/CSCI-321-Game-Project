using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWallFall : MonoBehaviour
{
    private Animation wallFallAnim;
    private TutorialController tC;
    private UITextSet textController;

    void Start()
    {
        wallFallAnim = GameObject.Find("Tutorial Block").GetComponent<Animation>();
        tC = GameObject.Find("Player").GetComponent<TutorialController>();
        textController = GameObject.Find("PanelScript").GetComponent<UITextSet>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(tC.hasFinishedTutorial()){
                print("Fall");
                wallFallAnim.Play("WallFall");
                tC.setSpawn("Initial Area 2 Spawn");
            }
            else{
                textController.setUIText("Looks like there was something you missed! Make sure to go back and learn all you can about this world!");
            }
        }
    }
}
