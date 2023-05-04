using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EnemySwordHit : MonoBehaviour
{
    private GameObject tempHolder;
    private Tier3EnemyCombatController ECC;

    void Start()
    {
        tempHolder = gameObject.transform.parent.gameObject;
        while(!tempHolder.CompareTag("Enemy")){
            tempHolder = tempHolder.transform.parent.gameObject;
        }
        ECC = tempHolder.GetComponent<Tier3EnemyCombatController>();
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
