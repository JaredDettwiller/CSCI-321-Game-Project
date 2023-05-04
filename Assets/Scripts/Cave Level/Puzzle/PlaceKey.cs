using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] barrels;

    void Start()
    {
        // Give a key to ONLY one barrel
        giveKeyToOneBarrelFromArray();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveKeyToOneBarrelFromArray()
    {
        if(barrels.Length == 1)
        {
            barrels[0].GetComponent<BarrelItemHandler>().setWillDropItem(true);
            barrels[0].GetComponent<BarrelItemHandler>().isKeyBarrel = true;
            return;
        }

        // Give to a random barrel
        int numberOfBarrels = barrels.Length;
        int barrelToPut = Random.Range(0, numberOfBarrels-1);

        barrels[barrelToPut].GetComponent<BarrelItemHandler>().setWillDropItem(true);
        barrels[barrelToPut].GetComponent<BarrelItemHandler>().isKeyBarrel = true;
    }
}
