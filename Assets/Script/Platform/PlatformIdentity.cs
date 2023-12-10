using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIdentity : MonoBehaviour
{
    [SerializeField]private int platformHeight;
    [SerializeField]private AreaEffector2D areaEffector2D;
    [SerializeField]private bool isWindy, isLeft, isDoing;
    [SerializeField]private float magnitudes, variations, moveDirectionTimerMax, moveDirectionTimer, waitTimerMax, waitTimer;
    [SerializeField]private ParticleSystem right, left;
    public void ChangeAreaEffector2D(float magnitude, float variation, float moveDirectionTimer, float waitTimer)
    {
        magnitudes = magnitude;
        variations = variation;
        moveDirectionTimerMax = moveDirectionTimer;
        waitTimerMax = waitTimer;
    }
    public void ChangePlatformHeight(int newPH)
    {
        platformHeight = newPH;
    }
    public void IsWindy()
    {
        isWindy = true;
    }
    private void Start() {
        moveDirectionTimer = moveDirectionTimerMax;
        // waitTimer = waitTimerMax;
    }
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Player"))
    //     {
    //         PlayerIdentity identity = other.GetComponent<PlayerIdentity>();
    //         if(identity.PlayerHeight() < platformHeight)identity.ChangePlayerHeight(platformHeight);
    //     }
    // }
    private void Update() 
    {
        if(isWindy)
        {
            if(waitTimer <= 0)
            {
                if(isLeft)
                {
                    if(!isDoing)
                    {
                        ChangeEffector(magnitudes, variations);
                        moveDirectionTimer = moveDirectionTimerMax;
                        isDoing = true;
                    }
                    else
                    {
                        left.Play();
                        moveDirectionTimer -= Time.deltaTime;
                        if(moveDirectionTimer <= 0)
                        {   
                            left.Stop();
                            isDoing = false;
                            waitTimer = waitTimerMax;
                            isLeft = false;
                        }
                    }
                    
                }
                else
                {
                    if(!isDoing)
                    {
                        ChangeEffector(-magnitudes, variations);
                        moveDirectionTimer = moveDirectionTimerMax;
                        isDoing = true;
                    }
                    else
                    {
                        right.Play();
                        moveDirectionTimer -= Time.deltaTime;
                        if(moveDirectionTimer <= 0)
                        {
                            right.Stop();
                            isDoing = false;
                            waitTimer = waitTimerMax;
                            isLeft = true;
                        }
                    }
                }
            }
            else
            {
                waitTimer -= Time.deltaTime;
                ChangeEffector(0, 0);
            }
            
        }
    }
    private void ChangeEffector(float magnitude, float variation)
    {
        areaEffector2D.forceMagnitude = magnitude;
        areaEffector2D.forceVariation = variation;
    }
    public int GetPlatformHeight()
    {
        return platformHeight;
    }
}
