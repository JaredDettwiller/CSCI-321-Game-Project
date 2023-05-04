using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2EnemyAuditory : MonoBehaviour
{
    private Tier2EnemyAI EAI;


    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier2EnemyAI>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setCanHearPlayer(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            EAI.setCanHearPlayer(false);
        }
    }
}
