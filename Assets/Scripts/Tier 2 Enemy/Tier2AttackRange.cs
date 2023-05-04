using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2AttackRange : MonoBehaviour
{
    private Tier2EnemyAI EAI;


    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier2EnemyAI>();
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
