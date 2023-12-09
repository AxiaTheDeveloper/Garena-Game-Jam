using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isFalling;
    [SerializeField] private bool runOnceFalling;
    [SerializeField] private bool runOnceJumping;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool playerHardLanded;
    [SerializeField] private bool isNotSlamming;
    [SerializeField] private bool isStuck;
    [SerializeField] private bool isDead;
    [SerializeField] private ParticleSystem particleEffectLanding;
    [SerializeField] private ParticleSystem particleEffectSlam;
    [SerializeField] private PlayerAttack playerAttackCollider;

    private void Awake()
    {
        isDead = false;
        particleEffectLanding = gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        particleEffectSlam = gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        playerAttackCollider = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (isFalling && !runOnceFalling && isNotSlamming && !isStuck && !isDead)
        {
            animator.Play("Falling");
            runOnceFalling = true;
        }
        if (isJumping && !runOnceJumping && !isFalling && !isDead)
        {
            animator.Play("Jump");
            runOnceJumping = true;
        }
    }
    public void PlayerWalk(bool change)
    {
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Landed") && !isStuck && !isDead)
        {
            if (change && !isFalling && !isJumping)
                animator.Play("Walk");
            else if (!change && !isFalling && !isJumping)
                animator.Play("Idle");
        }
       
    }
    public void PlayerJump()
    {
        isJumping = true;
    }
    public void PlayerFall()
    {
        isJumping = false;
        isFalling = true;
    }
    public void PlayerDoneFall()
    {
        if (isFalling && playerHardLanded && !isDead)
        {
            animator.Play("Landed");
            playerHardLanded = false;
        }
        isJumping = false;
        runOnceFalling = false;
        runOnceJumping = false;
        isFalling = false;
        isNotSlamming = true;
    }
    public void PlayerHardLanded()
    {
        playerHardLanded = true;
    }

    public void PlayerSlamming()
    {
        isNotSlamming = false;
        animator.Play("SlamLoop");
    }
    
    public void PlayParticleEffectLanding()
    {
        particleEffectLanding.Play();
    }
    public void PlayParticleEffectSlam()
    {
        var theShape = particleEffectSlam.shape;
        theShape.radius = playerAttackCollider.getRadius();
        particleEffectSlam.Play();
    }

    public void PlaySlamStuck()
    {
        isStuck = true;
        Debug.Log("Calleddddddddd");
        animator.Play("SlamStuck");
    }
    public void PlaySlamWakeUp()
    {
        animator.Play("SlamUnStuck");
    }

    public void UnStuck()
    {
        isStuck = false;
    }

    public bool GetUnstuck()
    {
        return isStuck;
    }
    public void DieAnimation()
    {
        isDead = true;
        animator.SetTrigger("Die");
    }
    public void Diee()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Death();

    }
}
