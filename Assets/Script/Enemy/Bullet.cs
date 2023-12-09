using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float bulletSpeed, bulletTimeMax, bulletTime;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Animator bulletAnimator;
    private bool isLaunching;
    private void Update() 
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            
            if(bulletTime > 0)
            {
                bulletTime -= Time.deltaTime;
                // Debug.Log(rb.velocity + "before");
            }
            else if(bulletTime <= 0 && isLaunching)
            {
                
                isLaunching = false;
                gameObject.SetActive(false);
                // Debug.Log(rb.velocity + "after");
            }
            if(!gameObject.activeSelf)Debug.Log("He ded");
            // Debug.Log(rb.velocity + " " + bulletTime);
            
        }
        
    }
    public void ShootBullet(int arah)
    {
        gameObject.SetActive(true);
        bulletTime = bulletTimeMax;
        isLaunching = true;
        rb.velocity = new Vector2(arah * bulletSpeed, 0f);
        // Debug.Log(rb.velocity + "sini");/
    }
    public void ChangeSpeed(float change)
    {
        bulletSpeed = change;
    }
    public void ChangeBulletTime(float change)
    {
        bulletTimeMax = change;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            if(!PlayerMovement.Instance.IsSlamming())other.GetComponent<PlayerIdentity>().Death();
            
        }
        if(other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("Ground"))
        {
            BackToNormal();
        }
        
    }
    public void BackToNormal()
    { 
        isLaunching = false;
        gameObject.SetActive(false);
    }

}
