using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float bulletSpeed, bulletTimeMax, bulletTime;
    [SerializeField]private Rigidbody2D rb;
    private void Update() 
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            if(bulletTime > 0)
            {
                bulletTime -= Time.deltaTime;
            }
            if(bulletTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
    public void ShootBullet(int arah)
    {
        gameObject.SetActive(true);
        bulletTime = bulletTimeMax;
        rb.velocity = new Vector2(arah * bulletSpeed, 0f);
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
            other.GetComponent<PlayerIdentity>().Death();
        }
    }

}
