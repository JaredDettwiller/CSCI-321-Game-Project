using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EnemyBlock : MonoBehaviour
{
    Tier3EnemyCombatController ECC;
    void Start(){
        ECC = this.transform.parent.gameObject.GetComponent<Tier3EnemyCombatController>();
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
