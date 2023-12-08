using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    [SerializeField]private int totalHitCanBeTaken;

    public void GotHit()
    {
        totalHitCanBeTaken-= 1;
        if(totalHitCanBeTaken == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
