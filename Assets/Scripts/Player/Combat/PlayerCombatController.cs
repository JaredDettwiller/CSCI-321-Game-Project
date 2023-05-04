using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    private float playerHealth = 100f;
    private float maxHealth = 100f;
    // will replace dealable damage with damage caused by sword being held at that moment later
    private float dealableDamage = 20f;
    public float damageMultiplier = 1f;
    //currently only set while the mouse is being clicked
    private bool isAttacking;
    private int attackType = 0;
    private Collider enemyCollider;
    private bool isBlocking;
    private bool inBlockTrigger;
    private PlayerAnimationController PAC;
    private float attackStart;
    private bool hitDuringAttack = false;
    private bool swordInEnemy = false;
    private bool isAlive = true;
    private bool swordInBarrel = false;
    public bool playSwordAudio = true;
    private Collider barrelCollider;
    public AudioClip swordHit;
    public AudioClip swordMiss;
    public GameObject gameOver;

    public float getPlayerHealth()
    {
        return this.playerHealth;
    }

    public void setPlayerHealthToMax()
    {
        this.playerHealth = this.maxHealth;
    }

    public float getMaxHealth()
    {
        return this.maxHealth;
    }

    public void addMaxHealth(float healthPoints)
    {
        this.maxHealth += healthPoints;
        this.healPlayerByHealth(healthPoints);  
    }

    /**
     * The healPlayerByHealth function will heal the player by
     * the healthToHealBy parameter.  If playerHealth + healthToHealBy > maxHealth,
     * then the player will be healed to max health.  Else, the health will be healed to
     * playerHealth + healthToHealBy.
     * 
     * This function will return false if the player is already at max health
     * and can't be healed.
     * 
     * This function will return true if the player has been healed.
     */
    public bool healPlayerByHealth(float healthToHealBy)
    {
        if (this.playerHealth == this.maxHealth)
        {
            return false;
        }


        if (this.playerHealth + healthToHealBy > this.maxHealth)
        {
            this.playerHealth = this.maxHealth;
        }
        else
        {
            this.playerHealth += healthToHealBy;
        }

        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        PAC = GetComponent<PlayerAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Barrel checks
        if(this.swordInBarrel && this.isAttacking)
        {
            if (this.barrelCollider != null)
            {
                this.breakBarrel(this.barrelCollider);
            }
            if(playSwordAudio)
            {
                GetComponent<AudioSource>().PlayOneShot(swordHit);
                playSwordAudio = false;
            }
        }

        // Enemy checks
        if(swordInEnemy && isAttacking){
            dealDamage(enemyCollider);
            
        }
        float timeSinceAttackStart = Time.unscaledTime - attackStart;
        if(playerHealth <= 0 && isAlive){
            if (this.gameObject.GetComponent<Inventory>().useFairy())
            {
                this.playerHealth = maxHealth / 2;
            }
            else
            {
                PAC.killPlayer();
                isAlive = false;
            }
        }
        if(attackType == 0 && timeSinceAttackStart > .8f && attackStart > 0f){
            hitDuringAttack = false;
            isAttacking = false;
            attackStart = 0f;
            //print("Attack Done" + timeSinceAttackStart);
        }
        else if(attackType == 1 && timeSinceAttackStart > 1.3f && attackStart > 0f){
            hitDuringAttack = false;
            isAttacking = false;
            attackStart = 0f;
            GetComponent<AudioSource>().PlayOneShot(swordMiss);
        }
    }

    public void startAttacking(){
        isAttacking = true;
        if(attackStart == 0f){
            attackStart = Time.unscaledTime;
        }
        //print("Attack time set to: " + attackStart);
    }

    public void setAttackType(int i){
        attackType = i;
    }

    public void setIsBlocking(bool state){
        isBlocking = state;
    }

    public void setInBlockTrigger(bool state){
        inBlockTrigger = state;
    }

    public void setSwordInEnemy(bool state, Collider enemy){
        swordInEnemy = state;
        enemyCollider = enemy;
    }

    public void setSwordInBarrel(bool swordInBarrel, Collider barrelCollider)
    {
        this.swordInBarrel = swordInBarrel;
        this.barrelCollider = barrelCollider;
    }
    public void Revive(){
        isAlive = true;
        PAC.RevivePlayer();
    }

    void breakBarrel(Collider barrel)
    {
        float time = Time.unscaledTime - attackStart;
        if (isAttacking && !hitDuringAttack)
        {
            GameObject barrelObject = barrelCollider.gameObject;
            if (barrelObject.GetComponent<EnemyCombatController>() != null)
            {
                if (attackType == 0 && time > 0.2)
                {
                    hitDuringAttack = true;
                }
                else if (attackType == 1 && time > 1f)
                {
                    hitDuringAttack = true;
                }
            }
            else if (barrelObject.GetComponent<Tier2EnemyCombatController>() != null)
            {
                if (attackType == 0 && time > 0.2)
                {
                    hitDuringAttack = true;
                }
                else if (attackType == 1 && time > 1f)
                {
                    hitDuringAttack = true;
                }
            }
            else
            {
                if (attackType == 0 && time > 0.2)
                {
                    hitDuringAttack = true;
                }
                else if (attackType == 1 && time > 1f)
                {
                    hitDuringAttack = true;
                }
            }

            if (hitDuringAttack)
            {
                DestroyOnHit barrelHit = barrelObject.GetComponent<DestroyOnHit>();
                barrelHit.DestroyBarrel(this.GetComponent<Collider>());
                this.barrelCollider = null;
                playSwordAudio = true;
            }
        }
    }

    void dealDamage(Collider enemy){
        float time = Time.unscaledTime - attackStart;
        if(isAttacking && !hitDuringAttack){
            GameObject enemyObject = enemy.gameObject;
            if(enemyObject.GetComponent<EnemyCombatController>() != null){
                if(attackType == 0 && time > 0.2){
                    enemyObject.GetComponent<EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                }
                else if(attackType == 1 && time > 1f){
                    enemyObject.GetComponent<EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                    //print("Attacked: " + time);
                }
            }
            else if(enemyObject.GetComponent<Tier2EnemyCombatController>() != null){
                if(attackType == 0 && time > 0.2){
                    enemyObject.GetComponent<Tier2EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                }
                else if(attackType == 1 && time > 1f){
                    enemyObject.GetComponent<Tier2EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                    //print("Attacked: " + time);
                }
            }
            else if(enemyObject.GetComponent<Tier3EnemyCombatController>() != null){
                if(attackType == 0 && time > 0.2){
                    enemyObject.GetComponent<Tier3EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                }
                else if(attackType == 1 && time > 1f){
                    enemyObject.GetComponent<Tier3EnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit,2);
                }
            }
            else
            {
                // If the attacking enemy is the boss
                if (attackType == 0 && time > 0.2)
                {
                    enemyObject.GetComponent<BossEnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit, 2);
                }
                else if (attackType == 1 && time > 1f)
                {
                    enemyObject.GetComponent<BossEnemyCombatController>().hasBeenHit(dealableDamage * damageMultiplier, attackType);
                    hitDuringAttack = true;
                    GetComponent<AudioSource>().PlayOneShot(swordHit, 2);
                }
            }
        }
    }

    public void takeDamage(float damagePotential, int hitType){
        if(hitType == 0){
            if(!isBlocking || !inBlockTrigger){
                playerHealth -= damagePotential;
                print("Player Health: " + playerHealth);
                PAC.setHit(0);
            }
        }
        else{
            //Need to script later to account for attacks that can't be blocked
            playerHealth -= damagePotential;
            print("Player Health: " + playerHealth);
            PAC.setHit(0);
        }
    }

    /**
     * This respawn method is an on click function
     * for when the player wants to restart the level.
     */
    public void respawn(){
        playerHealth = 100f;
        isAlive = true;

        // Make the player go back to the start of the current level
        GameObject sceneController = GameObject.Find("SceneController");
        sceneController.GetComponent<SceneController>().respawnPlayerInScene();
    }
}
