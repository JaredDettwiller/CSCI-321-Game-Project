using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2EnemyAI : MonoBehaviour
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
    private Tier2EnemyCombatController ECC;
    private bool playPlayerDetectedAudio = true;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        ECC = GetComponent<Tier2EnemyCombatController>();
        enemyCollider = GetComponent<CapsuleCollider>();
        enemyPos = GetComponent<Transform>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        patrolPositions = gameObject.transform.GetChild(2).gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform pos in patrolPositions){
            waypoints.Add(pos.position);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
        if(inDeath){
            return;
        }
        if(inAttackRange){
            agent.isStopped = true;
            float blockTime = Time.unscaledTime;
            if(!blockToAttack){
                if(blockStart == 0f){
                    blockStart = blockTime;
                    //print("Block Start: " + blockStart + "| blockTime: " + blockTime);
                    anim.SetBool("isAttacking", false);
                    ECC.startAttacking(false, 0f);
                    anim.SetBool("isBlocking", true);
                    ECC.setIsBlocking(true);
                }
                else if(blockTime > blockStart + 2f){
                    blockToAttack = true;
                    anim.SetBool("isBlocking", false);
                    ECC.setIsBlocking(false);
                    //print("Block End");
                    //print("Block Start: " + blockStart + "| blockTime: " + blockTime);
                }
                return;
            }
            else if(blockTime < blockStart + 6f){
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Slash 2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Weak Impact") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Strong Impact")){
                    //print("Attack Start");
                    anim.SetBool("isAttacking", true);
                    float attackStart = Time.unscaledTime; 
                    ECC.startAttacking(true, attackStart);
                }
                return;
            }
            else{
                //anim.SetBool("isAttacking", true);
                blockStart = 0f;
                blockToAttack = false;
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
            }
            else{
                if(agent.pathPending){
                    return;
                }
                if(!agent.hasPath || Vector3.Distance(agent.destination, enemyPos.position) < 0.5f){
                    agent.destination = waypoints[iterator];
                    iterator++;
                    if(iterator == count){
                        iterator = 0;
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
}
