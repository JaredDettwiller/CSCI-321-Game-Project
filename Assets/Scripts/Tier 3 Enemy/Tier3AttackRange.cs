using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3AttackRange : MonoBehaviour
{
    private Tier3EnemyAI EAI;
    private int placeInArray;
    private PlayerCombatController PCC;
    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier3EnemyAI>();
        PCC = GameObject.Find("Player").GetComponent<PlayerCombatController>();
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
