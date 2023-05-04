using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockTrigger : MonoBehaviour
{
    PlayerCombatController PCC;
    void Start(){
        PCC = GameObject.Find("Player").GetComponent<PlayerCombatController>();
    }

    void OnTriggerEnter(Collider other){
        //need to check if other Collider is enemy weapon
        if(other.gameObject.CompareTag("Enemy")){
            PCC.setInBlockTrigger(true);
        }
    }

    void OnTriggerExit(Collider other){
        //need to check if other Collider is enemy weapon
        if(other.gameObject.CompareTag("Enemy")){
            PCC.setInBlockTrigger(false);
        }
    }
}
