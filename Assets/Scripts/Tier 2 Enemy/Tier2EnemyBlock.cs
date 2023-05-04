using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2EnemyBlock : MonoBehaviour
{
    Tier2EnemyCombatController ECC;
    void Start(){
        ECC = this.transform.parent.gameObject.GetComponent<Tier2EnemyCombatController>();
    }

    void OnTriggerEnter(Collider other){
        //need to check if other Collider is enemy weapon
        ECC.setInBlockTrigger(true);
    }

    void OnTriggerExit(Collider other){
        //need to check if other Collider is enemy weapon
        ECC.setInBlockTrigger(false);
    }
}
