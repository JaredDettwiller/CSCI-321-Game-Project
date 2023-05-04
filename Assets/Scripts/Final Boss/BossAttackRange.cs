using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackRange : MonoBehaviour
{
    private BossEnemyAI EAI;
    private int placeInArray;
    private PlayerCombatController PCC;
    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<BossEnemyAI>();
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
