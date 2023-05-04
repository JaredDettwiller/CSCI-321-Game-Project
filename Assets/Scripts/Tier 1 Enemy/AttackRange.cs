using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    //Need to make this universal to each AI Tier
    private Tier1EnemyAI EAI;


    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier1EnemyAI>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setInAttackRange(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setInAttackRange(false);
        }
    }
} 
