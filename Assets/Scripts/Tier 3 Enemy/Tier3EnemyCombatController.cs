using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EnemyCombatController : MonoBehaviour
{
    PlayerCombatController PCC;
    PlayerProgressionController progressionController;

    //Need To Find a way to make universal
    Tier3EnemyAI AI;
    private Animator enemyAnim;
    private float health = 150f;
    private float damagePotential = 20f;
    private bool isBlocking = false;
    private bool inBlockTrigger = false;
    private bool isAlive = true;
    private bool isAttacking = false;
    private bool inRange = false;
    private bool weaponInPlayer = false;
    private bool hitDuringAttack = false;
    private float attackStart = 0f;
    private bool attackAudio = true;
    public AudioClip attack;

    void Start()
    {
        PCC = GameObject.Find("Player").GetComponent<PlayerCombatController>();
        progressionController = PCC.gameObject.GetComponent<PlayerProgressionController>();
        //need to find a way to make universal
        AI = GetComponent<Tier3EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && isAlive){
            isAlive = false;
            progressionController.addToPlayerExperiencePoints(40);
            AI.enemyKilled();
        }
        if(isAttacking){
            //upon creation of harder AI's logic for different attack types will be introduced
            hurtPlayer(0);
        }
        float timeSinceAttackStart = Time.unscaledTime - attackStart;
        if(timeSinceAttackStart > 1.3f && attackStart > 0f){
            resetAttack();
            //print("Attack Done" + timeSinceAttackStart);
        }
    }
    
    /*Blocking is not a feature of the Tier 1 AI */
    //hit type is either 0 for standard attack or 1 for strong attack
    public void hasBeenHit(float damage, int hitType){
        //if strong attack but attacking from front of enemy while they are blocking do 75% damage
        if(hitType == 1 && isBlocking && inBlockTrigger){
            health -= .75f * damage;
            AI.setEnemyHit(1);
            resetAttack();
        }
        //if strong attack but either enemy not blocking or player is attacking enemy from behind do 150% damage
        else if(hitType == 1){
            health -= 1.5f * damage;
            AI.setEnemyHit(1);
            resetAttack();
        }
        //if either enemy isn't blocking or player is attacking from behind do normal damage if attack type 0
        else if(!isBlocking || !inBlockTrigger){
            health -= damage;
            AI.setEnemyHit(0);
            resetAttack();
        }
        print("Enemy Health: " + health);
    } 

    public void setWeaponInPlayer(bool state){
        weaponInPlayer = state;
    }
    public bool hasDied(){
        return !isAlive;
    }

    public void startAttacking(bool state, float time){
        isAttacking = state;
        if(isAttacking && attackAudio)
        {
            GetComponent<AudioSource>().PlayOneShot(attack);
            attackAudio = false;
        }
        inRange = true;
        if(attackStart == 0f){
            attackStart = time;
        }
    }

    public void leftRange(){
        inRange = false;
        isBlocking = false;
    }

    public void setInBlockTrigger(bool state){
        inBlockTrigger = state;
    }
    public void setIsBlocking(bool state){
        isBlocking = state;
    }
    
    void resetAttack(){
        hitDuringAttack = false;
        isAttacking = false;
        attackAudio = true;
        attackStart = 0f;
    }
    void hurtPlayer(int attackType){
        float time = Time.unscaledTime - attackStart;
        if(!hitDuringAttack && inRange){
            if(attackType == 0 && time > 0.9f){
                //print("Time: " + Time.unscaledTime + " | AttackStart: " + attackStart + " | Time Difference: " + time);
                PCC.takeDamage(damagePotential, 0);
                hitDuringAttack = true;
            }
            else if(attackType == 1){
                PCC.takeDamage(damagePotential, 1);
                hitDuringAttack = true;
            }
        }
    }
}
