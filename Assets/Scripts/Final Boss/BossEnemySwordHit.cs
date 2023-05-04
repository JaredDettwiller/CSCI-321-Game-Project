using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemySwordHit : MonoBehaviour
{
    private GameObject tempHolder;
    private BossEnemyCombatController ECC;

    void Start()
    {
        tempHolder = gameObject.transform.parent.gameObject;
        while(!tempHolder.CompareTag("Enemy")){
            tempHolder = tempHolder.transform.parent.gameObject;
        }
        ECC = tempHolder.GetComponent<BossEnemyCombatController>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            ECC.setWeaponInPlayer(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            ECC.setWeaponInPlayer(false);
        }
    }
}
