using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBattle : MonoBehaviour
{
    private PlayerMusicController player;
    public GameObject lich;
    private BossEnemyCombatController lcc;
    private bool fightStart = false;
    public VictoryScreen victoryScreen;
    private bool battleEnded = false;
    
    void Start()
    {
        player = GameObject.Find("Main Camera").GetComponent<PlayerMusicController>();
        lich.SetActive(false);
        lcc = lich.GetComponent<BossEnemyCombatController>();
    }

    void Update()
    {
        if (lcc.hasDied() && !battleEnded)
        {
            endBattle();
            battleEnded = true;
        }
    }
    
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && fightStart != true)
        {
            fightStart = true;
            beginBattle();
        }
    }

    public void beginBattle()
    {
        player.finalBattleMusic();
        lich.SetActive(true);
    }

    public void endBattle()
    {
        player.victory();
        StartCoroutine(end());
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(3);
        victoryScreen.openVictoryPanel();
    }
}
