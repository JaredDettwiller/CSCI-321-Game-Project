using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveTwo : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] secondSpawnEnemies;
    private bool[] secondSpawnEnemyIsAlive;
    private bool[] enemyIsAlive;
    public bool isWaveOver;
    public Collider enterCollider;
    public Collider exitCollider;
    private int roundCount = 1;

    private void Start()
    {
        enemyIsAlive = new bool[enemies.Length];
        secondSpawnEnemyIsAlive = new bool[secondSpawnEnemies.Length];
        exitCollider.isTrigger = false;
        isWaveOver = false;

        // Spawn all enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            enemyIsAlive[i] = true;
        }
    }

    private void Update()
    {
        if (!isWaveOver)
        {
            // Check if the enemies are still alive
            if (!isOneEnemyAlive())
            {
                // If enemies are dead, get rid of collider
                // and destroy the wave object 
                if (roundCount == 1)
                {
                    roundCount++;
                    spawnSecondRound();
                }
                else
                {
                    isWaveOver = true;
                    exitCollider.isTrigger = true;
                    if(enterCollider != null)
                    {
                        enterCollider.isTrigger = true;
                    }
                }
            }
        }
    }

    bool isOneEnemyAlive()
    {
        bool returnBool = false;

        switch (roundCount) {
            case 1:
                for (int i = 0; i < enemies.Length && !returnBool; i++)
                {
                    GameObject enemy = enemies[i];
                    if (enemyIsAlive[i])
                    {
                        if (enemy.GetComponent<Animator>().GetBool("isDead"))
                        {
                            enemyIsAlive[i] = false;
                        }
                        else
                        {
                            returnBool = true;
                        }
                    }
                }
                break;

            case 2:
                for (int i = 0; i < secondSpawnEnemies.Length && !returnBool; i++)
                {
                    GameObject enemy = secondSpawnEnemies[i];
                    if (secondSpawnEnemyIsAlive[i])
                    {
                        if (enemy.GetComponent<Animator>().GetBool("isDead"))
                        {
                            enemyIsAlive[i] = false;
                        }
                        else
                        {
                            returnBool = true;
                        }
                    }
                }
                break;
        }
        return returnBool;
    }

    public static void startWaveTwo()
    {
        GameObject exitCollider = GameObject.Find("ExitWaveOneCollider");

        if (exitCollider)
        {
            print("exitCollider not found!");
            return;
        }
    }

    void spawnSecondRound()
    {
        // Spawn all enemies
        for (int i = 0; i < secondSpawnEnemies.Length; i++)
        {
            secondSpawnEnemies[i].SetActive(true);
            secondSpawnEnemyIsAlive[i] = true;
        }
    }
}
