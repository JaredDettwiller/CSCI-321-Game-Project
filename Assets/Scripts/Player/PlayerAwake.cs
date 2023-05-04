using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwake : MonoBehaviour
{
    /**
     *  This script makes sure that the player doesn't get destroyed.
     */
    private bool created = false;

    private void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
}
