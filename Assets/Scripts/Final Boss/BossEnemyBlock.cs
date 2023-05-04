using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBlock : MonoBehaviour
{
    BossEnemyCombatController ECC;
    void Start(){
        ECC = this.transform.parent.gameObject.GetComponent<BossEnemyCombatController>();
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
