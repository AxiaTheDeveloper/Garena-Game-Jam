using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private bool isFacingLeft;
    [SerializeField]private Transform leftPos, rightPos;
    [SerializeField]private float difDirectionTimer, difDirectionTimerMax;

    private void Update() 
    {
        if(GameManager.Instance.StateGame() == GameManager.GameStates.GameStart)
        {
            Move();
        }
        
    }
    private void Move()
    {
        if(isFacingLeft)
        {
            // Debug.Log(transform.position.x + " dan " + leftPos.position.x);
            if(transform.position.x > leftPos.position.x)
            {
                // Debug.Log("sini ???");
                if(transform.localScale.x != 1){
                    transform.localScale = new Vector3(1,1,1);
                }
                // rb.velocity = new Vector2(moveSpeed * -1, 0f);
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                difDirectionTimer = difDirectionTimerMax;
            }
            else
            {
                difDirectionTimer -= Time.deltaTime;
                if(difDirectionTimer <= 0)isFacingLeft = false;
                

            }
        }
        else if(!isFacingLeft)
        {
            if(transform.position.x < rightPos.position.x)
            {
                // Debug.Log("sana???");
                if(transform.localScale.x != -1){
                    transform.localScale = new Vector3(-1,1,1);
                }
                // rb.velocity = new Vector2(moveSpeed * 1, 0f);
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                // b.MovePosition(rb.position + keyInput * speedMovement * Time.fixedDeltaTime);
                // Debug.Log(rb.velocity);
                difDirectionTimer = difDirectionTimerMax;
            }
            else
            {
                difDirectionTimer -= Time.deltaTime;
                if(difDirectionTimer <= 0)isFacingLeft = true;
            }
        }
        
    }
}
