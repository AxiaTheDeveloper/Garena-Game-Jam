using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Destroyable"))
        {
            other.GetComponent<PlatformDestroy>().GotHit();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyIdentity>().Suicide();
        }
    }
}
