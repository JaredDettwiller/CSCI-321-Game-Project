using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCastle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("SceneController").GetComponent<SceneController>().castleFromOverworld();
        }
    }
}
