using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public void PleaseActuallyDie()
    {
        gameObject.transform.parent.GetComponent<EnemyIdentity>().YesPleaseDie();
    }
}
