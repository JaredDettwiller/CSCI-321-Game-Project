using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelOne : MonoBehaviour
{
    private GameObject caveBlock;
    private GameObject lvl2Trigger;
    private TutorialController TC;
    private bool blocked = false;

    void Start(){
        caveBlock = GameObject.Find("Lvl2 Jump").transform.GetChild(0).gameObject;
        lvl2Trigger = GameObject.Find("Lvl2 Jump").transform.GetChild(1).gameObject;
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
    }

    void Update(){
        if(!blocked){
            print("not blocked");
            if(TC.isCrystalBroken()){
                print("blocking");
                caveBlock.SetActive(true);
                lvl2Trigger.SetActive(false);
                blocked = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("SceneController").GetComponent<SceneController>().caveFromOverworld();
        }
    }
}
