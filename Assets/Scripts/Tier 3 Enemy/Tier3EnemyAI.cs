using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier3EnemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private CapsuleCollider enemyCollider;
    private Transform playerPos;
    private Transform enemyPos;
    private Transform[] patrolPositions;
    public List<Vector3> waypoints = new List<Vector3>();
    private int count = 0;
    private int iterator = 0;
    private bool inAttackRange = false;
    private bool canHearPlayer = false;
    private float fieldOfView = 124f;
    private bool inDeath = false;
    private bool blockToAttack = false;
    private float blockStart = 0f;
    private bool patroller = true;
    private Tier3EnemyCombatController ECC;
    private Vector3 sentryPos;
    private Tier3EyeLights eyes;
    private bool firstBlock = false;
    private bool takingDamage;
    private bool playPlayerDetectedAudio = true;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip playerDetected;
    

    // Start is called before the first frame update
    void Start()
    {
        ECC = GetComponent<Tier3EnemyCombatController>();
        enemyCollider = GetComponent<CapsuleCollider>();
        enemyPos = GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        eyes = GetComponent<Tier3EyeLights>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        if(gameObject.transform.GetChild(2).gameObject.activeSelf == false){
            patroller = false;
            sentryPos = enemyPos.position;
        }
        else{
            patrolPositions = gameObject.transform.GetChild(2).gameObject.GetComponentsInChildren<Transform>();
            foreach(Transform pos in patrolPositions){
                waypoints.Add(pos.position);
                count++;
            }
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
        if(inAttackRange && !takingDamage){
            agent.isStopped = true;
            
            float blockTime = Time.unscaledTime;
            if(!firstBlock){
                if(blockStart == 0f){
                    blockStart = blockTime;
                    anim.SetBool("isBlocking", true);
                    ECC.setIsBlocking(true);
                }
                else if(blockTime > blockStart + 2f){
                    firstBlock = true;
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
        }

        if(canHearPlayer){
            agent.destination = playerPos.position;
            eyes.PlayerInView(true);
        }
        else{
            Vector3 enemyToPlayer = playerPos.position - transform.position;
            float angleToPlayer = Vector3.Angle(enemyToPlayer, transform.forward);
            bool isAngleUnderHalfAngleOfView = angleToPlayer < fieldOfView * 0.5f;
            bool playerCloseEnough = Vector3.Distance(playerPos.position, enemyPos.position) < 10f;
            if(isAngleUnderHalfAngleOfView && playerCloseEnough){
                agent.destination = playerPos.position;
                if(playPlayerDetectedAudio)
                {
                    GetComponent<AudioSource>().PlayOneShot(playerDetected);
                    playPlayerDetectedAudio = false;
                }
                eyes.PlayerInView(true);
            }
            else{
                if(agent.pathPending){
                    return;
                }
                eyes.PlayerInView(false);
                if(patroller){
                    if((!agent.hasPath || Vector3.Distance(agent.destination, enemyPos.position) < 0.5f)){
                        agent.destination = waypoints[iterator];
                        iterator++;
                        if(iterator == count){
                            iterator = 0;
                        }
                    }
                }
                else{
                    if(!agent.hasPath || Vector3.Distance(agent.destination, enemyPos.position) < 0.5f){
                        agent.destination = sentryPos;
                    }
                    
                }
            }
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
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
        else if(type == 1){
            anim.SetTrigger("hasTakenDamageStrong");
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
        takingDamage = false;
    }
    public void enemyKilled(){
        agent.isStopped = true;
        anim.SetBool("isDead", true);
        anim.SetTrigger("killed");
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
                anim.SetBool("isBlocking", true);
                firstBlock = false;
                print("block");
            }
            else if(chanceToBlock <= 7){
                //initialize roll
                anim.SetBool("isAttacking", false);
                ECC.startAttacking(false, 0f);
                anim.SetBool("isBlocking", false);
                ECC.setIsBlocking(false);
                anim.SetTrigger("roll");
                print("roll");
            }
            else{
                //get hit
                anim.SetBool("isAttacking", false);
                ECC.startAttacking(false, 0f);
                anim.SetBool("isBlocking", false);
                ECC.setIsBlocking(false);
                takingDamage = true;
                print("get hit");
            }
        }
    }
}
