using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdentity : MonoBehaviour
{
    ParticleSystem WalkingGibsPE;
    Animator animator;

    private void Start()
    {
        animator = gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Animator>();
    }

    public void Suicide()
    {
        animator.Play("Die");
    }

    public void YesPleaseDie()
    {
        Destroy(this.gameObject);
    }
}
