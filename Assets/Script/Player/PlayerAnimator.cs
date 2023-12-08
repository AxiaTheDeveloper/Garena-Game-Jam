using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]private Animator animator;
    public void PlayerWalk(bool change)
    {
        animator.SetBool("IsWalking", change);
    }
}
