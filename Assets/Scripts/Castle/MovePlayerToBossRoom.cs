using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerToBossRoom : MonoBehaviour
{
    private GameObject player;
    public GameObject bossRoomEntrance;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = bossRoomEntrance.transform.position;
        }
    }
}
