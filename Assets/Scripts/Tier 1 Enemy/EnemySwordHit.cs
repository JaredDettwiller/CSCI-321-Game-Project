using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordHit : MonoBehaviour
{
    private GameObject tempHolder;
    private EnemyCombatController ECC;

    void Start()
    {
        tempHolder = gameObject.transform.parent.gameObject;
        while(!tempHolder.CompareTag("Enemy")){
            tempHolder = tempHolder.transform.parent.gameObject;
        }
        ECC = tempHolder.GetComponent<EnemyCombatController>();
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
