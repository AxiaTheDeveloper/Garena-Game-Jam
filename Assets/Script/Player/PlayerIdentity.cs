using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    public static PlayerIdentity Instance{get; private set;}
    [SerializeField]private int playerHeightNow;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAnimator playerAnimator;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        Instance = this;
    }
    public int PlayerHeight()
    {
        return playerHeightNow;
    }
    public void ChangePlayerHeight(int newHeight)
    {
        playerHeightNow = newHeight;
        if(PlatformSpawner.Instance.GetTotalHeight()-1 == newHeight)
        {
            PlatformSpawner.Instance.SpawnPlatform(3);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(!playerMovement.IsSlamming())Death();
            
        }
    }
    public void Death()
    {
        playerAnimator.DieAnimation();
        // GameManager.Instance.Death();
    }
}
