using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    private bool finishedTutorial;
    private int numTasksCompleted = 0;
    private bool crystalBroken = false;
    private SceneController SC;

    void Start(){
        SC = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    void Update()
    {
        if(numTasksCompleted == 11){
            finishedTutorial = true;
        }
    }


    public bool hasFinishedTutorial(){
        return finishedTutorial;
    }

    public void incrementTasksCompleted(){
        numTasksCompleted += 1;
    }

    public void breakCrystal(){
        crystalBroken = true;
    }

    public bool isCrystalBroken(){
        return crystalBroken;
    }

    public void setSpawn(string spawn){
        SC.setNextSpawnName(spawn);
    }
}
