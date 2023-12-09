using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualShoot : MonoBehaviour
{
    [SerializeField]private EnemyShoot enemyShoot;
    public void Shoot()
    {
        enemyShoot.CanShoot();
    }
}
