using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Hal Penting")]
    [SerializeField]private GameInput gameInput;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private PlayerRotation playerRotation;
    [SerializeField]private PlayerAnimator playerAnimator;
    
    [Header("Player Movement Horizontal")]
    [SerializeField]private float moveSpeed;
    [SerializeField]private Vector2 moveDirection;
    [SerializeField]private float accelerate, deccelerate, moveFriction;
    [Header("Player Movement Vertical")]
    [SerializeField]private float jumpForce;
    [SerializeField]private Vector2 checkGroundSize;
    [SerializeField]private bool isOnGround, isJumping, isJumpCut;
    [SerializeField]private float lastOnGroundTime, lastInputJumpTime, coyoteTime, jumpInputBuffer;
    [SerializeField]private float defaultGravScale, gravScaleMultiplier, maxFallSpeed;
    [Header("Player Slam")]
    [SerializeField]private bool isSlamming, firstHitSlam;
    [SerializeField]private float slamGravScaleMultiplier, slamingCooldownTime, slamingCooldown;
    [SerializeField]private GameObject slamAttack;
    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() 
    {
        if(!gameInput)gameInput = GameInput.Instance;
    }
    private void Update() 
    {
        if(isOnGround)
        {
            if(isSlamming)
            {
                if(firstHitSlam)
                {
                    firstHitSlam = false;
                    StartCoroutine(SlamAttack());
                }
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
                if(moveDirection != Vector2.zero)moveDirection = Vector2.zero;
                slamingCooldown-= Time.deltaTime;
                if(slamingCooldown <= 0)isSlamming = false;
            }
            else
            {
                moveDirection = gameInput.GetInputPlayerDirection();
            }
            
        }
        else
        {
            if(gameInput.GetInputSlam() && rb.velocity.y != 0)
            {
                Slam();
            }
            if(rb.velocity.y == 0 && !isJumping)moveDirection = gameInput.GetInputPlayerDirection();
            // moveDirection != Vector2.zero;
        }
        if(moveDirection != Vector2.zero)
        {
            playerRotation.Rotate(moveDirection.x);
        }
        
        
        JumpPlayer();
    }
    private IEnumerator SlamAttack()
    {
        slamAttack.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        slamAttack.SetActive(false);
    }
    private void FixedUpdate() 
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if(moveDirection.x == 0)
        {
            playerAnimator.PlayerWalk(false);
        }
        else playerAnimator.PlayerWalk(true);
        
        float targetSpeed = moveDirection.x * moveSpeed;
        float speedDif_TargetStart = targetSpeed - rb.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? accelerate : deccelerate;
        float movement = speedDif_TargetStart * accelRate;
        rb.AddForce(movement * Vector2.right);
    }
    private void Friction()
    {
        if(lastOnGroundTime > 0 && moveDirection.x == 0)
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(moveFriction));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }
    }
    private bool JumpInput()
    {
        if(gameInput.GetInputDownJump())
        {
            lastInputJumpTime = jumpInputBuffer;
            return lastOnGroundTime > 0 && !isJumping;
        }
        return false;
    }
    private void JumpPlayer()
    {
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        lastOnGroundTime -= Time.deltaTime;
        lastInputJumpTime -= Time.deltaTime;

        if(!isSlamming)
        {
            if(isJumpCut)
            {
                SetPlayerGravityScale(defaultGravScale * gravScaleMultiplier);
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
                // Debug.Log(Mathf.Max(rb.velocity.y, -maxFallSpeed));
            }
            else if(rb.velocity.y <= 0)
            {
                SetPlayerGravityScale(defaultGravScale * gravScaleMultiplier);
                // Debug.Log(Mathf.Max(rb.velocity.y, -maxFallSpeed));
            }
            else SetPlayerGravityScale(defaultGravScale);
        }
        
        
        if(!isJumping)
        {
            if(Physics2D.OverlapBox(transform.position - new Vector3(0,0.5f), checkGroundSize, 0, groundLayer))
            {
                playerAnimator.PlayerDoneFall();
                SetPlayerGravityScale(defaultGravScale);
                lastOnGroundTime = coyoteTime;
                isOnGround = true;
                if (rb.velocity.y < -5 && !isSlamming)
                    playerAnimator.PlayerHardLanded();
            }
            else
            {
                isOnGround = false;
            }
        }
        if(rb.velocity.y < 0 && isJumping)
        {
            isJumping = false;
        }
        if(rb.velocity.y < 0 && !isOnGround)
        {
            // Debug.Log("This");
            
            playerAnimator.PlayerFall();
        }
        
        
        if(JumpInput() && lastInputJumpTime > 0 && !isSlamming)
        {
            lastInputJumpTime = 0;
            lastOnGroundTime = 0;
            float tempForce = jumpForce;
            if(rb.velocity.y < 0)
            {
                tempForce -= rb.velocity.y;
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
            }
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playerAnimator.PlayerJump();

            isJumping = true;
            isJumpCut = false;
            isOnGround = false;

        }

        if(gameInput.GetInputUpJump())
        {
            if(CanJumpCut())isJumpCut = true;
        }
        
    }
    private bool CanJumpCut()
    {
        return isJumping && rb.velocity.y > 0;
    }
    private void SetPlayerGravityScale(float newGravScale)
    {
        rb.gravityScale = newGravScale;
    }
    private void Slam()
    {
        isSlamming = true;
        SetPlayerGravityScale(defaultGravScale * slamGravScaleMultiplier);
        
        slamingCooldown = slamingCooldownTime;
        // Debug.Log(Mathf.Max(rb.velocity.y, -maxFallSpeed));
        firstHitSlam = true;
    }
    public bool IsSlamming()
    {
        return isSlamming;
    }
    public void ChangeJumpForce(int change)
    {
        jumpForce *= change;
    }
}
