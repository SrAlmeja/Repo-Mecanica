using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    [SerializeField]float jumpForce;
    int jumpLimit;
    private Vector3 theVector;
    [SerializeField] float moveVector;
    [SerializeField] float acelerationMove;
    public bool isGrounded;
    [SerializeField]float fallForce = (-9.81f);
    Vector3 moveDirection;


    void Start()
    {
        jumpForce = 20;
        moveVector = 5*(Time.deltaTime + 1);
    }

    void Update()
    {
        RightMovement();
        LeftMovement();
        //Debug.Log(gameObject.transform.position.magnitude);
        CheckFloar();
        fall();
        gameObject.transform.position += theVector * Time.deltaTime;
        gameObject.transform.position += moveDirection * Time.deltaTime;
        Jump();
        Down();
        if(!isGrounded)
        {
            jumpForce = -(jumpForce - fallForce);
            fallForce += ((-9.81f * Time.deltaTime));
        }
        else if(isGrounded)
        {
            fallForce = 0;
            jumpForce = 20;
        }
    }
    
     void RightMovement()
     {
         if (Input.GetKeyDown(KeyCode.D))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection += (rightMove);
         }
     }
     void LeftMovement()
     {
         if (Input.GetKeyDown(KeyCode.A))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection -= (rightMove);
         }
     }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            if(jumpForce >= 0.1)
                {
                    theVector += (jump);
                }
                else if(jumpForce <= 0)
                    {
                        theVector -= jump;
                    }
            Debug.Log("jumping >D");
        }   
    }
    void Down()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jump = new Vector3 (0, theVector.y, 0);
            theVector -= jump;
            Debug.Log("AntiSaltanding");
        }
    }

    void fall()
    {
        Vector3 falling = new Vector3(0,fallForce, 0); 
        if(!isGrounded)
        {
            gameObject.transform.position += falling * Time.deltaTime;
        }
        else
        {
             gameObject.transform.position += (falling * -1) * Time.deltaTime;
        }
    }

    void CheckFloar()
    {
        float previo;
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
            previo = fallForce;
            fallForce = 0;
        }
        else
        {
            fallForce = -9.81f;
            isGrounded = false;  
        }
    }
}
