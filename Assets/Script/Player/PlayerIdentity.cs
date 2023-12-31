using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour
{
    public static PlayerIdentity Instance{get; private set;}
    [SerializeField]private int playerHeightNow;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private PlayerAnimator playerAnimator;
    [SerializeField]private float startHeight_m, totalHeight, maxHeight =0;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        Instance = this;
    }
    private void Update() 
    {
        totalHeight = transform.position.y - startHeight_m;
        if(totalHeight > maxHeight)maxHeight = totalHeight;
    }
    public int PlayerHeight()
    {
        return playerHeightNow;
    }
    public float GetMaxHeight()
    {
        return maxHeight;
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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        playerAnimator.DieAnimation();
        GameManager.Instance.Death();
    }
    public float GetHeight()
    {
        return totalHeight;
    }
}
