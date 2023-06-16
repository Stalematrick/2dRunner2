using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{   
    public float gravity;
    public Vector2 velocity ;
    public float maxXVelocity = 100;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;  
    public float jumpVelocity = 20;
    public float groundHeight = 10;         
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldingJumpTime = 0.4f;
    public float HoldJumpTimer = 0.0f; 
    public float JumpGroundDistance = 1;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y-groundHeight);
        if(isGrounded || groundDistance<= JumpGroundDistance)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded=false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                HoldJumpTimer = 0;

            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump=false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                HoldJumpTimer += Time.fixedDeltaTime;
                if(HoldJumpTimer >=maxHoldingJumpTime)
                {
                    isHoldingJump = false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if(!isHoldingJump)
            {
                 velocity.y+=gravity * Time.fixedDeltaTime;  
            }
            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if(hit2D.collider!=null)
            {
                Groundscrtpt  ground = hit2D.collider.GetComponent<Groundscrtpt>();
                if(ground != null)
                {
                    if(pos.y >= ground.groundHeight){
                    groundHeight = ground.groundHeight;
                    pos.y = groundHeight;
                    isGrounded = true;
                    velocity.y = 0;
                    }
            //     isGrounded = true;
            // }
                }
            }
            Debug.DrawRay(rayOrigin, rayDirection*rayDistance,Color.green);
            // Vector2 wallOrigin = new Vector2(pos.x, pos.y);
            // RaycastHit2D wallHit = Physics2D.Raycast(wallOrigin,Vector2.right, velocity.x * Time.fixedDeltaTime);
            // if (wallHit.collider != null)
            // {
            //     Groundscrtpt ground =wallHit.collider.GetComponent<Groundscrtpt>();
            //     if(ground!=null)
            //     {
            //         if(pos.y<ground.groundHeight)sad
            //         {
            //             velocity.x = 0;
            //         }
            //     }
            // }
            // if(pos.y <= groundHeight)
            // {
            //     pos.y = groundHeight;
            //     isGrounded = true;
            // }
        }
        distance += velocity.x * Time.fixedDeltaTime;
        if(isGrounded)
        {
            float velocityRatio = velocity.x/ maxXVelocity;
            acceleration = maxAcceleration* (1-velocityRatio);
            velocity.x += acceleration* Time.fixedDeltaTime;
            if(velocity.x >=maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
            Vector2 rayOrigin = new Vector2(pos.x - 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
            if(hit2D.collider==null)
            {
               isGrounded =false;

            }
            Debug.DrawRay(rayOrigin, rayDirection*rayDistance,Color.green);
        } 




        transform.position = pos;
    }
}   

