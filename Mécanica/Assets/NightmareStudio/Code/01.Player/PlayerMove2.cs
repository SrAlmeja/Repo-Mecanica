using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    //Movement
    [SerializeField] float moveVector;
    Vector3 moveDirection;
    public float moveForce;
    public float aceleration;
    float finalSpeed;
    float startSpeed;

    //Jump
    public bool isGrounded;
    [SerializeField]float DesacelerationJump;
    [SerializeField]float inicialJumpForce;
    [SerializeField]float finalJumpForce;
    Vector3 verticalDirection;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        moveForce = 0.05f;
        finalSpeed = 0.2f;

        if (Input.GetKeyDown(KeyCode.D))
       {
            aceleration = (finalSpeed - moveForce)/Time.deltaTime;
            moveVector = aceleration;
            Vector3 rightMove = new Vector3 (moveVector,0,0);
            moveDirection = (rightMove);
        }
        if (Input.GetKeyUp(KeyCode.D))
       {
            Vector3 rightMove = new Vector3 (0,0,0);
            moveDirection = (rightMove);
        }
        if (Input.GetKeyDown(KeyCode.A))
       {
            aceleration = (finalSpeed - moveForce)/Time.deltaTime;
            moveVector = -aceleration;
            Vector3 rightMove = new Vector3 (moveVector,0,0);
            moveDirection = (rightMove);
        }
        if (Input.GetKeyUp(KeyCode.A))
       {
            Vector3 rightMove = new Vector3 (0,0,0);
            moveDirection = (rightMove);
        }
        gameObject.transform.position += (moveDirection)* Time.deltaTime;
    }
    void Jump()
    {
        inicialJumpForce = 30;
        finalJumpForce = 2;
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            DesacelerationJump = ((inicialJumpForce - finalJumpForce) / Time.deltaTime);
            Vector3 jump = new Vector3 (0,DesacelerationJump,0);
            verticalDirection += (jump)Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jump = new Vector3 (0, 0, 0);
            verticalDirection = (jump)Time.deltaTime;
        }
        gameObject.transform.position += (verticalDirection) * Time.deltaTime;
    }

    void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;  
        }
    }
}
