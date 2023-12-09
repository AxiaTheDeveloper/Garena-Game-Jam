using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIdentity : MonoBehaviour
{
    [SerializeField]private int platformHeight;
    [SerializeField]private AreaEffector2D areaEffector2D;
    [SerializeField]private bool isWindy, isLeft;
    [SerializeField]private float magnitudes, variations;
    public void ChangeAreaEffector2D(float magnitude, float variation)
    {
        magnitudes = magnitude;
        variations = variation;
    }
    public void ChangePlatformHeight(int newPH)
    {
        platformHeight = newPH;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIdentity identity = other.GetComponent<PlayerIdentity>();
            if(identity.PlayerHeight() < platformHeight)identity.ChangePlayerHeight(platformHeight);
        }
    }
    
}
