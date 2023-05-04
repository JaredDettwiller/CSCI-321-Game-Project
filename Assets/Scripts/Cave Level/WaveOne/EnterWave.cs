using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The EnterWave class will start a wave upon a user entering a trigger.
 * 
 * The wave handler will store enemies and deal with logic.
 * 
 * The enter collider is something that can be added (optional) as something to
 * block for when the user enters.
 */
public class EnterWave : MonoBehaviour
{
    public Collider enterCollider;
    public GameObject waveHandler;

    private void OnCollisionEnter(Collision collision)
    {
        if(!gameObject.GetComponent<Collider>().isTrigger && collision.gameObject.CompareTag("Player"))
        {
            GameObject textBox = GameObject.Find("Textbox");
            textBox.GetComponent<TextboxTrigger>().DisplayTextInPanel("BrightCrystalText");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Collider>().isTrigger && other.gameObject.CompareTag("Player"))
        {
            if (enterCollider)
            {
                enterCollider.isTrigger = false;
            }

            // Start the wave
            waveHandler.SetActive(true); // Starts the wave

            // Destroy the trigger
            Destroy(this);
        }
    }
}
