using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveOne : MonoBehaviour
{
    public GameObject[] enemies;
    private bool[] enemyIsAlive;
    public Collider exitCollider;

    private void Start()
    {
        enemyIsAlive = new bool[enemies.Length];

        // Spawn all enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            enemyIsAlive[i] = true;
        }
    }

    private void Update()
    {
        // Check if the enemies are still alive
        if (!isOneEnemyAlive())
        {
            // If enemies are dead, get rid of collider
            // and destroy the wave object 
            exitCollider.isTrigger = true;
            Destroy(this);
        }
    }

    bool isOneEnemyAlive()
    {
        bool returnBool = false;
        for (int i = 0; i < enemies.Length && !returnBool; i++)
        {
            GameObject enemy = enemies[i];
            if (enemyIsAlive[i])
            {
                if(enemy.GetComponent<Animator>().GetBool("isDead"))
                {
                    enemyIsAlive[i] = false;
                }
                else
                {
                    returnBool = true;
                }
            }
        }
        return returnBool;
    }
}
