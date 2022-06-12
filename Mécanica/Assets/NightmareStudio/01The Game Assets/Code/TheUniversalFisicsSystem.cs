using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheUniversalFisicsSystem : MonoBehaviour
{
    public GameObject theObject;
    public GameObject [] planets;
    float closeDistance;
    int closerPlanet = 0;
    float planetDistance;
    //Planet Direction
    Vector3 verticalGravity;
    //Gravity Force
    Vector3 fallingObject;
    float gravityForce;
    //Aceleration
    public float finalSpeedx;
    public float finalSpeedy;
    public float initialSpeed;
    [SerializeField] float fallSpeed;
    public float fallSpeedController;
    [SerializeField] Vector3 acelerationSpeed;
    //Atmosphere
    [SerializeField]bool SpaceGravity;
    //Drag
    float constant;
    float Density;
    bool dragZone;
    //CheckFlour
    [SerializeField] bool isGrounded;
    float oldFallingForce;
    float oldFinalSpeed;
    //Friction
    bool friction;
    int coeficientFriction;
    float WeightObject;
    public float mass;
    public Vector3 frictionVect;
    //Jump
    private float directionfall;
    
    [SerializeField] private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        SpaceGravity = false;
    }
    // Update is called once per frame
    void Update()
    {
        GravitySystem();
        jump();
    }
    void GravitySystem(){
        
        //Vertical Gravity
        if (!SpaceGravity)
        {
            directionfall = -1f;
            Vector3 objectPos = new Vector3 (theObject.transform.position.x, theObject.transform.position.y, 0);
            Vector3 gravityDirection = new Vector3 (0, ((objectPos.y - 1)), 0);
            acelerationSpeed = new Vector3 ((finalSpeedx-initialSpeed), (finalSpeedy-initialSpeed), 0);
            fallSpeed = ((Mathf.Pow(acelerationSpeed.y, 2))) * fallSpeedController;
            //Drag System
            constant = 0.5f;
            float speed = acelerationSpeed.magnitude;
            Vector3 dragVector =  constant * Density * speed * fallingObject;
            //GravityAction
            if(!isGrounded){
                
                if(dragVector.magnitude >= fallingObject.magnitude){
                    finalSpeedx = 0;
                    finalSpeedy = 0;
                    acelerationSpeed = new Vector3 (0,0,0);
                    fallingObject = Vector3.zero;
                }
                else{
                    finalSpeedx = 1 - (dragVector.x);
                    finalSpeedy = 1 - (dragVector.y);
                }
                fallingObject += ((gravityDirection * fallSpeed)*directionfall);
            }
            if(isGrounded)
            {
                fallSpeedController = 0;
                //finalSpeedx = 0;
                finalSpeedy = 0;
                fallingObject = (Vector3.zero);
                acelerationSpeed = new Vector3 (0,0,0);
                Debug.Log("Colisione");

                if(friction == true)
                {   
                    Debug.Log("Friction is true");
                    float normalForce = mass * 9.8f;
                    coeficientFriction = 1;
                    frictionVect = (-coeficientFriction * normalForce * gameObject.transform.position.normalized)/10;
                    Debug.Log("FrictionVectValue"+frictionVect);
                }
            }
            
        }
        else //Planet Gravity
        {
            //Distance & Position
            closeDistance = Vector3.Distance(transform.position, planets[0].transform.position);
            for(int i = 0; i<planets.Length; i++){
                planetDistance = Vector3.Distance(transform.position, planets[i].transform.position);
                if (planetDistance <= closeDistance) {closeDistance = planetDistance; closerPlanet = i;}
            }
            //Planet/Object Position
            Vector3 objectPos = new Vector3 (theObject.transform.position.x, theObject.transform.position.y, 0);
            Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x, planets[closerPlanet].transform.position.y,0);
            //FallDirection
            Vector3 gravityDirection = new Vector3 (((objectPos.x - planetPos.x)), ((objectPos.y - planetPos.y)), 0);
            Vector3 uniGravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
            //Aceleration
            acelerationSpeed = new Vector3 ((finalSpeedx-initialSpeed), (finalSpeedy-initialSpeed), 0);
            fallSpeed = (Mathf.Sqrt ((Mathf.Pow(acelerationSpeed.x, 2)) + (Mathf.Pow(acelerationSpeed.y, 2)))) * fallSpeedController;
            //Mass (Fix first)
            gravityForce = Mathf.Sqrt (((Mathf.Pow(fallingObject.x, 2)) + ((Mathf.Pow(fallingObject.y, 2)))));
            //Drag System}
            constant = 0.5f;
            float speed = acelerationSpeed.magnitude;
            Vector3 dragVector =  constant * Density * speed * fallingObject;
            //GravityAction
            if(!isGrounded){
                fallingObject += ((uniGravity * fallSpeed)*directionfall);
                if(dragVector.magnitude >= fallingObject.magnitude){
                    finalSpeedx = 0;
                    finalSpeedy = 0;
                    acelerationSpeed = new Vector3 (0,0,0);
                    fallingObject = Vector3.zero;
                }
                else{
                    finalSpeedx = 1 - (dragVector.x);
                    finalSpeedy = 1 - (dragVector.y);
                }
            }

            if (isGrounded)
            {
                fallSpeedController = 0;
                //finalSpeedx = 0;
                finalSpeedy = 0;
                fallingObject = (Vector3.zero);
                acelerationSpeed = new Vector3(0, 0, 0);
                Debug.Log("Colisione");
                if (friction == true)
                {
                    Debug.Log("Friction is true");
                    float normalForce = mass * 9.8f;
                    coeficientFriction = 1;
                    frictionVect = (-coeficientFriction * normalForce * gameObject.transform.position.normalized) / 10;
                    Debug.Log("FrictionVectValue" + frictionVect);
                }
                if (isJumping = true)
                {
                    directionfall = 1;
                    fallingObject = ((uniGravity * fallSpeed)*directionfall);
                }
            }
            //Rotation
            theObject.transform.rotation = Quaternion.FromToRotation(transform.up, uniGravity)* transform.rotation;
        }
        gameObject.transform.Translate(fallingObject*Time.deltaTime);
    }

    void jump()
    {
        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
            isGrounded = false;
        }
        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Atmosphere")
        {
            Debug.Log("cambiando a la gravedad planetaria");
            SpaceGravity = true;
        }
        
        if(other.tag == "Drag")
        {
            Debug.Log("Jelly funciona");
            dragZone = true;
            isGrounded = true;
            Density = other.gameObject.GetComponent<GetDensity>().density; 
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Atmosphere")
        {
            Debug.Log("cambiando a gravedad normal");
            SpaceGravity = false;
            theObject.transform.rotation = Quaternion.EulerRotation(0,0,0);
        }
        
        if(other.tag == "Drag")
        {
            dragZone = false;
            isGrounded = false;
            Debug.Log("Exit");
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Colisione");
        if(other.gameObject.tag == "Planet")
        {
            isGrounded = true;
            Debug.Log("Colisione");
        }
        
        if(other.gameObject.tag == "FrictionZone")
        {
            isGrounded = true;
            friction = true;
        }
        
    }
    private void OnCollisionExit(Collision other)
    {
        Debug.Log ("No hay nada");
        if (other.gameObject.tag == "Planet")
        {
            isGrounded = false;
            //fallingObject = (Vector3.zero);
            fallSpeedController = 0.002f;
            finalSpeedx = 1;
            finalSpeedy = 1;
            
        }
        if(other.gameObject.tag == "FrictionZone")
        {
            isGrounded = false;
            friction = false;
            fallSpeedController = 0.002f;
            finalSpeedx = 1;
            finalSpeedy = 1;
            frictionVect = Vector3.zero;
        }
    }
}

