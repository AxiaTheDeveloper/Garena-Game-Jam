using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField]private float startGoingUpTimer;
    [SerializeField]private float LavaGoingUpSpeedStart, LavaGoingUpSpeed, lavaMultiplier;
    [SerializeField]private int[] batasMaXPlayerDenganLava;
    [SerializeField]private PlayerAttack playerAttack;
    // [SerializeField]private float[] speedMultiplier;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private Transform lavaTop;
    private void Update() 
    {
        // Debug.Log(lavaTop.position.y);
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            if(startGoingUpTimer > 0)startGoingUpTimer -= Time.deltaTime;
            else
            {
                int playerHeight = PlayerIdentity.Instance.PlayerHeight();
                LavaGoingUpSpeed = LavaGoingUpSpeedStart * (playerHeight/5+1);
                int plus = playerAttack.GetJumpGiftCounter();
                for(int i=0;i<plus;i++)
                {
                    LavaGoingUpSpeed *= lavaMultiplier;
                }
                // rb.velocity = new Vector2(0f, 1 * LavaGoingUpSpeedStart);
                if(playerHeight/10 == 0)
                {
                    if(PlayerIdentity.Instance.GetHeight() - lavaTop.position.y > 36)//4*9
                    {
                        LavaGoingUpSpeed = 3;
                    }
                }
                else if(playerHeight/10 == 1)
                {
                    if(PlayerIdentity.Instance.GetHeight() - lavaTop.position.y > 27)//4*9
                    {
                        LavaGoingUpSpeed = 3;
                    }
                }
                else
                {
                    if(PlayerIdentity.Instance.GetHeight() - lavaTop.position.y > 18)//4*9
                    {
                        LavaGoingUpSpeed = 3;
                    }
                }
               
                transform.Translate(Vector3.up * LavaGoingUpSpeed * Time.deltaTime);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("DestroyByLava"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerIdentity>().Death();
            //keluar player diedd
        }
    }
    
}
