using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Move
    public GameObject player;
    [SerializeField]float jumpForce;
    int jumpLimit;
    [SerializeField] float moveVector;
    [SerializeField] float acelerationMove;
    [SerializeField]float fallForce = (-9.81f);
    Vector3 moveDirection;
    Vector3 verticalDirection;
    float elapsedTime;
    bool jumptime;

    //Gravity 
   public GameObject[] planets;
   float fallSpeed;
   Vector3 planetPosition;
   Vector3 PlayerPosition;
   public Vector3 gravity;
   //Planets Distance
   float closeDistance;
   int closerPlanet = 0;
   float planetDistance;
   //CheckFloar
   public bool isGrounded;
   

    void Start() 
    {
        elapsedTime = 0;   
    }
    void Update()
    {
        //Movement
        jumpForce  = 40;
        Movement();
        Jump();
        Fall();

        //Gravity
        //Checking the closer planet
        closeDistance = Vector3.Distance(transform.position, planets[0].transform.position);
        for(int i = 0; i<planets.Length; i++)
        {
            planetDistance = Vector3.Distance(transform.position, planets[i].transform.position);
            if (planetDistance <= closeDistance) {closeDistance = planetDistance; closerPlanet = i;}
            Debug.Log(closerPlanet);
        }
        CheckFloar();
        GravityFisics();
    }
    void Movement()
     {
         moveVector = 5*Time.deltaTime;
         if (Input.GetKey(KeyCode.D))
         {
             transform.Translate(new Vector3 (moveVector,0,0));
         }
         if (Input.GetKey(KeyCode.A))
         {
             transform.Translate(new Vector3 (-moveVector,0,0));
         }
     }

     void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            verticalDirection += (jump);
            jumptime = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            
            verticalDirection -= (jump);
        }
        gameObject.transform.position += (verticalDirection)* Time.deltaTime;
        if (jumptime == false){
            gameObject.transform.position -= (verticalDirection)* Time.deltaTime;
        }
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
    public void GravityFisics()
    {
        //Gravity Fisics
        fallSpeed -= 0.0981f * Time.deltaTime;
        Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y,0);
        Vector3 playerPos = new Vector3 (player.transform.position.x,player.transform.position.y,0);
        Vector3 gravityDirection = new Vector3 ((playerPos.x - planetPos.x),(playerPos.y - planetPos.y),0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        

        if(!isGrounded)
        {
            gameObject.transform.position += (gravity.normalized * fallSpeed);
        }
        player.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation; 
        return;
    }
    

    public void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,1f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.left,0.5f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.right,0.5f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.up,1f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else
        {
            isGrounded = false;
            return;
        }
    }
}
