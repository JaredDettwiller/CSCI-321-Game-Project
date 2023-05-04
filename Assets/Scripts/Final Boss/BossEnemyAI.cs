using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private CapsuleCollider enemyCollider;
    private Transform playerPos;
    private Transform enemyPos;
    private int count = 0;
    private int iterator = 0;
    private bool inAttackRange = false;
    private bool canHearPlayer = false;
    private float fieldOfView = 124f;
    private bool inDeath = false;
    private bool blockToAttack = false;
    private float blockStart = 0f;
    private bool patroller = true;
    private BossEnemyCombatController ECC;
    private Vector3 sentryPos;
    private bool firstBlock = false;
    private bool takingDamage;
    public AudioClip death;
    public AudioClip shieldUp;
    public bool playShieldUp = true;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        ECC = GetComponent<BossEnemyCombatController>();
        enemyCollider = GetComponent<CapsuleCollider>();
        enemyPos = GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        shield.SetActive(false);
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        if(gameObject.transform.GetChild(2).gameObject.activeSelf == false){
            patroller = false;
            sentryPos = enemyPos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
        if(inDeath){
            return;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) == true){
            GoingToBlock();
        }
        if(inAttackRange){
            agent.isStopped = true;
            
            float blockTime = Time.unscaledTime;
            if(!firstBlock){
                if(blockStart == 0f){
                    blockStart = blockTime;
                    shield.SetActive(true);
                    if(playShieldUp)
                    {
                        GetComponent<AudioSource>().PlayOneShot(shieldUp);
                        playShieldUp = false;
                    }
                    anim.SetBool("isBlocking", true);
                    ECC.setIsBlocking(true);
                }
                else if(blockTime > blockStart + 2f){
                    firstBlock = true;
                    shield.SetActive(false);
                    playShieldUp = true;
                    anim.SetBool("isBlocking", false);
                    ECC.setIsBlocking(false);
                }
                return;
            }
            else{
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Slash 2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Weak Impact") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Strong Impact")){
                    //print("Attack Start");
                    anim.SetBool("isAttacking", true);
                    float attackStart = Time.unscaledTime; 
                    ECC.startAttacking(true, attackStart);
                }
                return;
            }

        }
        else{
            agent.isStopped = false;
            anim.SetBool("isAttacking", false);
            anim.SetBool("isBlocking", false);
            //print("here 4");
            blockStart = 0f;
            blockToAttack = false;
            ECC.leftRange();
            agent.destination = playerPos.position;
        }

        
    }

    public void setInAttackRange(bool state){
        inAttackRange = state;
    }
    public void setCanHearPlayer(bool state){
        canHearPlayer = state;
    }
    public void setEnemyHit(int type){
        if(type == 0){
            anim.SetTrigger("hasTakenDamageNormal");
        }
        else if(type == 1){
            anim.SetTrigger("hasTakenDamageStrong");
        }
        takingDamage = false;
    }
    public void enemyKilled(){
        agent.isStopped = true;
        anim.SetBool("isDead", true);
        anim.SetTrigger("killed");
        shield.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(death);
        inDeath = true;
        Destroy(GetComponent<CapsuleCollider>(), 0);
        Destroy(gameObject, 15);
    }

    public void GoingToBlock(){
        agent.isStopped = true;
        int chanceToBlock = Random.Range(1, 10);
        if(inAttackRange){
            if(chanceToBlock <= 3){
                //if is going to block start with
                ECC.setIsBlocking(true);
                anim.SetBool("isAttacking", false);
                ECC.startAttacking(false, 0f);
                blockStart = Time.unscaledTime + 0.5f;
                shield.SetActive(true);
                if(playShieldUp)
                {
                    GetComponent<AudioSource>().PlayOneShot(shieldUp);
                    playShieldUp = false;
                }
                anim.SetBool("isBlocking", true);
                firstBlock = false;
                print("block");
            }
            else if(chanceToBlock <= 7){
                //initialize roll
                anim.SetBool("isAttacking", false);
                ECC.startAttacking(false, 0f);
                shield.SetActive(false);
                playShieldUp = true;
                anim.SetBool("isBlocking", false);
                ECC.setIsBlocking(false);
                anim.SetTrigger("roll");
                print("roll");
            }
            else{
                //get hit
                anim.SetBool("isAttacking", false);
                ECC.startAttacking(false, 0f);
                shield.SetActive(false);
                playShieldUp = true;
                anim.SetBool("isBlocking", false);
                ECC.setIsBlocking(false);
                takingDamage = true;
                print("get hit");
            }
        }
    }
}
