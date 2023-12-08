using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIdentity : MonoBehaviour
{
    [SerializeField]private int platformHeight;
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
