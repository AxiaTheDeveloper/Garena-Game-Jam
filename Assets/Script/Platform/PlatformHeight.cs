using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHeight : MonoBehaviour
{
    [SerializeField]private PlatformIdentity platformIdentity;
    private void Awake() {
        platformIdentity = GetComponentInParent<PlatformIdentity>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerIdentity identity = other.GetComponent<PlayerIdentity>();
            if(identity.PlayerHeight() < platformIdentity.GetPlatformHeight())identity.ChangePlayerHeight(platformIdentity.GetPlatformHeight());
        }
    }
}
