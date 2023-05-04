using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAuditory : MonoBehaviour
{
    //Need to make this universal to each AI Tier
    private Tier1EnemyAI EAI;


    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier1EnemyAI>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setCanHearPlayer(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setCanHearPlayer(false);
        }
    }
} 
