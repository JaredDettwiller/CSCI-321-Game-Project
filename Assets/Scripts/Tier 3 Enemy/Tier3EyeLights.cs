using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EyeLights : MonoBehaviour
{
    private GameObject left;
    private GameObject right;
    private GameObject eyes;
    
    void Start()
    {
        eyes = gameObject.transform.GetChild(0).gameObject;
        for (int i = 0; i < 4; i++){
            eyes = eyes.transform.GetChild(0).gameObject;
        }
        eyes = eyes.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        left = eyes.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        right= eyes.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
    }

    public void PlayerInView(bool seen){
        if(seen == true){
            left.SetActive(true);
            right.SetActive(true);
        }
        else{
            left.SetActive(false);
            right.SetActive(false);
        }
    }
}
