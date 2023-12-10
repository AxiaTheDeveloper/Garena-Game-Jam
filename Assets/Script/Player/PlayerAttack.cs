using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackSizeMultiplier, jumpforceMultiplier;
    [SerializeField]private BoxCollider2D coll;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private int giftNumber, attackGiftCounter, jumpGiftCounter;
    [SerializeField]private InGameUI inGameUI;
    private int enemyKilledTotal = 0;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Destroyable"))
        {
            other.GetComponent<PlatformDestroy>().GotHit();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            GachaGift();
            other.GetComponent<EnemyIdentity>().Suicide();
            enemyKilledTotal++;
        }
    }
    private void GachaGift()
    {
        //0 -> 70%
        //1,2,3 -> 15,15,15
        int i = 0;
        while(i < 7)
        {
            giftNumber = Random.Range(0,2);
            i++;
        }
        if(giftNumber == 1)
        {
            i = 0;
            while(i<3)
            {
                giftNumber = Random.Range(1,4);
                i++;
            }
            if(giftNumber == 1)
            {
                attackGiftCounter++;
                inGameUI.UpdateAttGiftVisual(attackGiftCounter);
                coll.size = new Vector2(coll.size.x * attackSizeMultiplier, coll.size.y);
                SFXManager.Instance.PlayPowerUp();
            }
            else if(giftNumber == 2)
            {
                jumpGiftCounter++;
                inGameUI.UpdateJumpGiftVisual(jumpGiftCounter);
                playerMovement.ChangeJumpForce(jumpforceMultiplier);
                SFXManager.Instance.PlayPowerUp();
            }
        }
        else
        {
            Debug.Log("Anda kurang beruntung");
        }

    }
    public float getRadius()
    {
        return coll.size.x;
    }
    public int GetEnemyKillTotal()
    {
        return enemyKilledTotal;
    }
    public int GetAttackGiftCounter()
    {
        return attackGiftCounter;
    }
    public int GetJumpGiftCounter()
    {
        return jumpGiftCounter;
    }
}
