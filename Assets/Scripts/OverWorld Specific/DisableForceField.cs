using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableForceField : MonoBehaviour
{
    private GameObject forceField;
    private GameObject guards;
    private TutorialController TC;
    private bool forceFieldDisabled = false;
    void Start()
    {
        TC = GameObject.Find("Player").GetComponent<TutorialController>();
        forceField = transform.GetChild(0).gameObject;
        guards = transform.GetChild(1).gameObject;
    }


    void Update()
    {
        if(!forceFieldDisabled){
            if(TC.isCrystalBroken()){
                forceField.SetActive(false);
                guards.SetActive(true);
                forceFieldDisabled = true;
            }
        }
    }
}
