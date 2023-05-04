using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossBattle : MonoBehaviour
{
    public PlayerAnimationController player;
    public Tier3EnemyCombatController miniboss;
    public GameObject bridge1;
    public GameObject bridge2;
    public AudioClip minibossMusic;
    public AudioClip victory;
    public AudioSource podium;
    public bool fightStart = false;
    private bool battleEnded = false;

    public void OnTriggerStay(Collider other)
    {
        podium = GetComponent<AudioSource>();
        podium.clip = minibossMusic;
        podium.loop = true;
        if(other.gameObject.CompareTag("Player") && fightStart != true)
        {
            fightStart = true;
            beginBattle();
        }
    }

    void Update()
    {
        if (miniboss.hasDied() && !battleEnded)
        {
            endBattle();
            battleEnded = true;
        }
    }

    public void beginBattle()
    {
        bridge1.SetActive(false);
        bridge2.SetActive(false);
        podium.Play();
    }

    public void endBattle()
    {
        bridge1.SetActive(true);
        bridge2.SetActive(true);
        podium.clip = victory;
        podium.loop = false;
        podium.playOnAwake = true;
        podium.Play();
    }
}
