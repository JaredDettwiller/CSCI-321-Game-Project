using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<TutorialController>().isCrystalBroken())
        {
            GameObject.Find("SceneController").GetComponent<SceneController>().overworldFromCave();
        }
    }
}
