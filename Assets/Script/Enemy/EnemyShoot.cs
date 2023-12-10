using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]private Transform bulletPrefab;
    [SerializeField]private float bulletSpeed, shootDelay, shootDelayTime;
    [SerializeField]private int totalBullet, bulletNumber;
    private List<Transform> bullets = new List<Transform>();
    private bool canShoot, canStartCoolDownNow;
    [SerializeField]private Animator playerAnimator;

    private void Update() 
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            
            
            playerAnimator.enabled = true;
        }
        else
        {
            playerAnimator.enabled = false;
        }
        
    }
    public void CanShoot()
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            canShoot = true;
            Shoot();
            
        }
        
    }
    public void Shoot()
    {
        while(canShoot && bulletNumber < totalBullet)
        {
            
            canShoot = false;
            if(bullets == null || bullets.Count != totalBullet)
            {
                // Debug.Log("HEEEsY");
                Debug.Log(gameObject + "instantiate");
                Transform bullet = Instantiate(bulletPrefab, this.gameObject.transform);
                bullet.transform.localPosition = new Vector3(0.45f, -0.25f,0f);
                
                bullets.Add(bullet);
                bullets[bulletNumber].GetComponent<Bullet>().ChangeSpeed(bulletSpeed);
                bullets[bulletNumber].GetComponent<Bullet>().ChangeBulletTime(shootDelayTime);
                bullets[bulletNumber].GetComponent<Bullet>().ShootBullet((int)transform.localScale.x);
                shootDelay = shootDelayTime;
                bulletNumber++;
            }
            else
            {
                // Debug.Log("HEEEY");
                bullets[bulletNumber].transform.localPosition = new Vector3(0.45f, -0.25f,0f);
                bullets[bulletNumber].GetComponent<Bullet>().ShootBullet((int)transform.localScale.x);
                shootDelay = shootDelayTime;
                bulletNumber++;
            }
            SFXManager.Instance.PlayShoot();
            
        }
        if(bulletNumber == totalBullet)
        {
            // canStartCoolDownNow = true;
            // canStartCoolDownNow = false;
                // canShoot = true;
                bulletNumber = 0;
        }
        
    }
    
}
