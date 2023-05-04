using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EnemyAuditory : MonoBehaviour
{
    private Tier3EnemyAI EAI;


    void Start()
    {
        EAI = this.transform.parent.gameObject.GetComponent<Tier3EnemyAI>();
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
