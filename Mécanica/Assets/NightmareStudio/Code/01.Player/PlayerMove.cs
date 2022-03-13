using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    [SerializeField]float jumpForce;
    int jumpLimit;
    [SerializeField] float moveVector;
    [SerializeField] float acelerationMove;
    public bool isGrounded;
    [SerializeField]float fallForce = (-9.81f);
    Vector3 moveDirection;
    Vector3 verticalDirection;


    void Update()
    {
        fallForce = -9.81f;
        jumpForce = 20;
        moveVector = 5*(Time.deltaTime + 1);

        //Debug.Log(gameObject.transform.position.magnitude);
        Movement();
        Jump();
        Fall();
        CheckFloar();

    }
    
     void Movement()
     {
         if (Input.GetKeyDown(KeyCode.D))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection += (rightMove);
         }
         if (Input.GetKeyDown(KeyCode.A))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection -= (rightMove);
         }
         gameObject.transform.position += (moveDirection * Time.deltaTime)+((moveDirection/10) * Time.deltaTime);
         if (Input.GetKeyUp(KeyCode.D))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection += (-rightMove/3);
         }
         if (Input.GetKeyUp(KeyCode.A))
         {
             Vector3 rightMove = new Vector3 (moveVector,0,0);
             moveDirection -= (rightMove/3);
         }
         gameObject.transform.position += (moveDirection * Time.deltaTime)+((moveDirection/10) * Time.deltaTime);
     }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            verticalDirection += (jump);
        
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            
            verticalDirection -= (jump)*Time.deltaTime;
        }
        gameObject.transform.position += (verticalDirection);
    }

    void Fall()
    {
        Vector3 falling = new Vector3(0,fallForce, 0); 
        if(!isGrounded)
        {
            gameObject.transform.position += falling * Time.deltaTime;
        }
        else
        {
             gameObject.transform.position += (falling * -1)*Time.deltaTime;
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
            fallForce = -5;
            isGrounded = false;  
        }
    }
}
