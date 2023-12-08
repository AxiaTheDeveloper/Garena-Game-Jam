using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdentity : MonoBehaviour
{
    public void Suicide()
    {
        Destroy(this.gameObject);
    }

}
