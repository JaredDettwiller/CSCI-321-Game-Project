using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordTrigger : MonoBehaviour
{
    PlayerCombatController PCC;
    // Start is called before the first frame update
    void Start()
    {
        PCC = GameObject.Find("Player").GetComponent<PlayerCombatController>();
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemy")){
            PCC.setSwordInEnemy(true, other);
        }

        if(other.gameObject.CompareTag("Barrel"))
        {
            PCC.setSwordInBarrel(true, other);
        }

        // Break the crystal
        if(other.gameObject.name.Equals("Crystal"))
        {
            // Check if wave two is over
            GameObject waveTwo = GameObject.Find("WaveTwoHandler");
            
            if (waveTwo.GetComponent<StartWaveTwo>().isWaveOver)
            {
                GameObject textObject = GameObject.Find("Textbox");
                textObject.GetComponent<TextboxTrigger>().DisplayTextInPanel("BrokeCrystalText");
                GameObject.Find("Player").GetComponent<TutorialController>().breakCrystal();
                Destroy(GameObject.Find("Crystal Light"));
            }
            else
            {
                GameObject textObject = GameObject.Find("Textbox");
                textObject.GetComponent<TextboxTrigger>().DisplayTextInPanel("CantBreakCrystalText");
            }
        }
    }

    void OnTriggerExit(Collider other){
        PCC.setSwordInEnemy(false, other);
        if (other.gameObject.CompareTag("Barrel"))
        {
            PCC.setSwordInBarrel(false, other);
        }
    }
}
