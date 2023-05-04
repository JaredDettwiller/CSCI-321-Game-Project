using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    PlayerCombatController PCC;
    // Start is called before the first frame update
    void Start()
    {
        PCC = GetComponent<PlayerCombatController>();
        anim = GetComponent<Animator>();
        anim.SetBool("hasDied", false);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
        if(Input.GetKey(KeyCode.LeftShift) == true){
            anim.SetBool("isSprinting", true);
        }
        else{
            anim.SetBool("isSprinting", false);
        }
        if(Input.GetKey(KeyCode.Space) == true){
            anim.SetBool("isJumping", true);
        }
        else{
            anim.SetBool("isJumping", false);
        }
        if(Input.GetKey(KeyCode.Mouse0) == true){
            //This Check will Change when combos are added
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Standing Slash")){
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Sprint")){
                    PCC.setAttackType(1);
                }
                else{
                    PCC.setAttackType(0);
                }
                PCC.startAttacking();
                anim.SetBool("isAttacking", true);
            }
        }
        else{
            anim.SetBool("isAttacking", false);
        }
        if(Input.GetKey(KeyCode.Mouse1) == true){
            anim.SetBool("isBlocking", true);
            PCC.setIsBlocking(true);
        }
        else{
            anim.SetBool("isBlocking", false);
            PCC.setIsBlocking(false);
        }
        if(Input.GetKey(KeyCode.Q) == true){
            anim.SetBool("isRolling", true);
        }
        else{
            anim.SetBool("isRolling", false);
        }
    }

    public void killPlayer(){
        anim.SetTrigger("playerKilled");
        anim.SetBool("hasDied", true);

        GameObject gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.GetComponent<GameOverCanvas>().startGameOverProcess();
    }
    public void setHit(int type){
        if(type == 0){
            anim.SetTrigger("hit");
        }
        else if(type == 1){
            anim.SetTrigger("strongHit");
        }
    }

    public void RevivePlayer(){
        anim.SetBool("hasDied", false);
    }
}