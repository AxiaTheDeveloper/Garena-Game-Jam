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

    private void Update()
    {
        if (isFalling && !runOnceFalling)
        {
            animator.Play("Falling");
            runOnceFalling = true;
        }
        if (isJumping && !runOnceJumping && !isFalling)
        {
            animator.Play("Jump");
            runOnceJumping = true;
        }
    }
    public void PlayerWalk(bool change)
    {
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Landed"))
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
        if (isFalling && playerHardLanded)
        {
            Debug.Log("Landed!");
            animator.Play("Landed");
            playerHardLanded = false;
        }
        runOnceFalling = false;
        runOnceJumping = false;
        isFalling = false;
    }
    public void PlayerHardLanded()
    {
        playerHardLanded = true;
    }
}
