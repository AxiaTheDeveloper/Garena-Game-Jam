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
    private void Awake() {
        Transform bull =  Instantiate(bulletPrefab);
        bull.gameObject.SetActive(false);
    }
    private void Update() 
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            if(shootDelay > 0)
            {
                // Debug.Log(shootDelay);
                shootDelay -= Time.deltaTime;

            }
            
            else
            {
                {
                    canShoot = true;
                }
            }
            Shoot();
            if(canStartCoolDownNow)
            {
                canStartCoolDownNow = false;
                // canShoot = true;
                bulletNumber = 0;
                shootDelay = shootDelayTime;
            }
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
                Transform bullet = Instantiate(bulletPrefab, this.gameObject.transform);
                bullet.transform.position = transform.position;
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
                bullets[bulletNumber].transform.position = transform.position;
                bullets[bulletNumber].GetComponent<Bullet>().ShootBullet((int)transform.localScale.x);
                shootDelay = shootDelayTime;
                bulletNumber++;
            }
            
        }
        if(bulletNumber == totalBullet)
        {
            canStartCoolDownNow = true;
            
        }
        
    }
    
}
