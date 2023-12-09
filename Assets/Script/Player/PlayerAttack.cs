using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackSize;//1 ganti attack size
    [SerializeField]private float attackSizeMultiplier;
    [SerializeField]private BoxCollider2D coll;
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField]private int giftNumber;
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
                // attackSize *= attackSizeMultiplier;
                Debug.Log("collider");
                coll.size = new Vector2(coll.size.x * attackSizeMultiplier, coll.size.y);
            }
            else if(giftNumber == 2)
            {
                Debug.Log("Jump Force");
                playerMovement.ChangeJumpForce(2);
            }
            // else if(giftNumber == 3)
            // {
            //     playerMovement.ChangeJumpForce(2);
            // }
        }
        else
        {
            Debug.Log("Anda kurang beruntung");
        }

    }
}
