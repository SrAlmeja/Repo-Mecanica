using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheUniversalFisicsSystem : MonoBehaviour
{
    //Planets Detection
    Vector3 planetPos;
    Vector3 objectPos;
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
    //Athmos
    bool SpaceGravity;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GravitySystem();
    }
    void VerticalGravity(){
        Vector3 objectPos = new Vector3 (theObject.transform.position.x, theObject.transform.position.y, 0);
        Vector3 gravityDirection = new Vector3 (objectPos.x, ((objectPos.y - 1)*fallSpeed*Time.deltaTime), 0);
        acelerationSpeed = new Vector3 (((finalSpeedx-initialSpeed)/Time.deltaTime), ((finalSpeedy-initialSpeed)/Time.deltaTime), 0);
        fallSpeed = (Mathf.Sqrt ((Mathf.Pow(acelerationSpeed.x, 2)) + (Mathf.Pow(acelerationSpeed.y, 2)))) * fallSpeedController;
        fallingObject += ((gravityDirection * fallSpeed)*-1);
        //Aqui me quede ayer
    }
    void GravitySystem(){
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
        Vector3 gravityDirection = new Vector3 (((objectPos.x - planetPos.x)*fallSpeed*Time.deltaTime), ((objectPos.y - planetPos.y)*fallSpeed*Time.deltaTime), 0);
        Vector3 uniGravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        //Aceleration
        acelerationSpeed = new Vector3 (((finalSpeedx-initialSpeed)/Time.deltaTime), ((finalSpeedy-initialSpeed)/Time.deltaTime), 0);
        fallSpeed = (Mathf.Sqrt ((Mathf.Pow(acelerationSpeed.x, 2)) + (Mathf.Pow(acelerationSpeed.y, 2)))) * fallSpeedController;
        fallingObject += ((uniGravity.normalized * fallSpeed)*-1);
        //Mass (Fix first)
        gravityForce = Mathf.Sqrt (((Mathf.Pow(fallingObject.x, 2)) + ((Mathf.Pow(fallingObject.y, 2)))));
        //Drag System
        constant = 0.5f;
        float speed = acelerationSpeed.magnitude;
        Vector3 dragVector =  constant * Density * speed * fallingObject;
        //GravityAction
        if(!isGrounded){
            gameObject.transform.Translate((fallingObject+dragVector)*Time.deltaTime);
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
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Drag")
        {
            Debug.Log("Jelly funciona");
            dragZone = true;
            Density = other.gameObject.GetComponent<GetDensity>().density; 
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Drag")
        {
            dragZone = false;
            Debug.Log("Exit");
        }    
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Colisione");
        if(other.gameObject.tag == "Planet")
        {
            isGrounded = true;
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
