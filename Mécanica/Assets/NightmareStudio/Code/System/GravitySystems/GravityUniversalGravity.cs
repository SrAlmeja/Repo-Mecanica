using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUniversalGravity : MonoBehaviour
{
    //
    //GravitySystem
    //PlanetDetection
    Vector3 planetPos;
    Vector3 objectPos;
    public GameObject[] planets;
    public GameObject theObject;
    float closeDistance;
    int closerPlanet = 0;
    float planetDistance;
    //Gravity Direction
    Vector3 gravity;
    //Gravity Force
    Vector3 fallingObject;
    float gravityForce;
    //Aceleration
    public float finalSpeedx;
    public float finalSpeedy;
    public float  initialSpeed;
    [SerializeField] float fallSpeed;
    public float fallSpeedController;
    [SerializeField] Vector3 acelerationSpeed;
    //Drag
    float constant;
    float density;
    bool dragZone;
    //CheckFlour
    [SerializeField] bool isGrounded;
    float oldFallingForce;
    float oldFinalSpeed;
    //Friction
    bool  friction;
    int coeficientFriction;
    float WeightObject;
    public float mass;
    public Vector3 frictionVect;
    
    
    
    void Update() 
    {
        ObjectsDistance();
        GravityFisicsSystem();
    }

    void ObjectsDistance()
    {
        closeDistance = Vector3.Distance(transform.position, planets[0].transform.position);    
        for(int i = 0; i<planets.Length; i++)
        {
            planetDistance = Vector3.Distance(transform.position, planets[i].transform.position);
            if (planetDistance <= closeDistance) {closeDistance = planetDistance; closerPlanet = i;}
            Debug.Log("Closer Planet " + closerPlanet);
        }
    }

    void GravityFisicsSystem()
    {
        //Distance
        Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x, planets[closerPlanet].transform.position.y, 0);
        Vector3 objectPos = new Vector3 (theObject.transform.position.x, theObject.transform.position.y, 0);
        //Fall Direction
        Vector3 gravityDirection = new Vector3 ((objectPos.x - planetPos.x), (objectPos.y - planetPos.y), 0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);

        //Masa
        gravityForce = Mathf.Sqrt (((Mathf.Pow(gravity.x, 2)) + ((Mathf.Pow(gravity.y, 2)))));
        
        //Debug.Log("Gravityforce " + gravityForce);

        //Aceleration
        acelerationSpeed = new Vector3 (((finalSpeedx-initialSpeed)/Time.deltaTime), ((finalSpeedy-initialSpeed)/Time.deltaTime), 0);
        fallSpeed = (Mathf.Sqrt ((Mathf.Pow(acelerationSpeed.x, 2)) + (Mathf.Pow(acelerationSpeed.y, 2)))) * fallSpeedController;
        //fallSpeed = ((acelerationSpeed.x + acelerationSpeed.y)/2) * fallSpeedController;
        fallingObject += ((gravity.normalized * fallSpeed)*-1);
        
        // Gravity Action
        if(!isGrounded)
        {
            gameObject.transform.position += fallingObject;
            if(dragZone == true)
            {
                Drag();
            }
            else
            {
                acelerationSpeed = new Vector3 (0,0,0);
                fallingObject = (Vector3.zero);
                finalSpeedx = 1;
                finalSpeedy = 1;
            }
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

        //Rotation
        theObject.transform.rotation = Quaternion.FromToRotation(transform.up, gravity)* transform.rotation;
        return;
    }
    void Drag() 
    {
        constant = 0.5f;
        float speed = acelerationSpeed.magnitude;
        Vector3  dragVector = constant * density * speed * fallingObject.normalized;
        //float dragFloat= Mathf.Sqrt (((Mathf.Pow(dragVector.x, 2)) + ((Mathf.Pow(dragVector.y, 2)))));
        Debug.Log("dragFloat" + dragVector);    
        //gameObject.transform.position += dragVector;
        if(dragVector.magnitude >= fallingObject.magnitude)
        {
            finalSpeedx = 0;
            finalSpeedy = 0;
            acelerationSpeed = new Vector3 (0,0,0);
            fallingObject = (Vector3.zero);
            //gameObject.transform.position += dragVector; 
            //fallingObject += (gravity.normalized * fallSpeed);
        }
        else
        {
            finalSpeedx = 1 - (dragVector.x);      
            finalSpeedy = 1 - (dragVector.y);         
        }
        Debug.Log("Drag vector" + dragVector);
        Debug.Log("Density " + density);
        Debug.Log("speed " + speed);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Drag")
        {
            Debug.Log("Jelly funciona");
            dragZone = true;
            density = other.gameObject.GetComponent<GetDensity>().density; 
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
