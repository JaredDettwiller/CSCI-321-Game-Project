using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    public GameObject keyPad;
    float timescale;
    private void Start()
    {
        timescale = Time.timeScale;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = !keyPad.activeInHierarchy ? 0 : timescale;
            keyPad.SetActive(!keyPad.activeInHierarchy);
        }
    }
}
