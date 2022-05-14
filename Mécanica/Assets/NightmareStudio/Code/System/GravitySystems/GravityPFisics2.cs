using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPFisics2 : MonoBehaviour
{
    //Gravity
   public GameObject[] planets;
   public GameObject theObject;
   float gravityForce;
   Vector2 planetPosition;
   Vector2 objectPosition;
   Vector3 gravity;
   Vector2 mass;
   public VectorVariable mass2;
   float AtractionForce1;
   float AtractionForce2;
   float closeDistance;
   int closerPlanet = 0;
   float planetDistance;
   [SerializeField]Vector2 weightObject;
   [SerializeField] Vector2 gravityLaw;
   Vector2 Object1Position;
   Vector2 Object2Position;
   public float fallSpeed;
   [SerializeField] float distanceBetweenObjects;
   //Aceleration
   [SerializeField]Vector2 acelerationSpeed;
   public float FinalSpeed;
   float InitialSpeed;
   //CheckFloar
   public bool isGrounded;
   //Segunda prueba
   public float fallSpeed2;
   //Drag
   float Density;
   float Zone = 1;
   float Coeficient = 1;
   float speed;
   Vector3 move;
   Vector3 dragVector;
   bool dragZone;

    private bool Drag = false;
    private bool friction = false;


    void Update()
    {
        ObjectsDistance();
        //CheckFloar();
        GravitySystem();
        transform.Translate(move);
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

    void GravitySystem()
    {
        
        //Distance
        Vector2 planetPos = new Vector2 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y);
        Vector2 objectPos = new Vector2 (theObject.transform.position.x,theObject.transform.position.y);
        //Fall Direction
        Vector2 gravityDirection = new Vector2 ((objectPos.x - planetPos.x),(objectPos.y - planetPos.y));
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        //Aceleration
        acelerationSpeed = new Vector3 (((FinalSpeed-InitialSpeed)/Time.deltaTime), ((FinalSpeed-InitialSpeed)/Time.deltaTime),0);
        fallSpeed = ((acelerationSpeed.x + acelerationSpeed.y)/2)*fallSpeed2;
        //Masa
        //mass = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
        //Peso de objetos
        weightObject =  new Vector2 ((mass.x * gravity.x), (mass.y * gravity.y));
        //Gravity
        //distanceBetweenObjects =((gravityDirection.x + gravityDirection.y)/2);
        //Ley de la Gravitacion universal
        //Vector3 gravityLaw = new Vector3 ((gravity.x*((mass.x*mass2.Value.x))/(Mathf.Pow(distanceBetweenObjects,2))),(gravity.y*((mass.y*mass2.Value.y))/(Mathf.Pow(distanceBetweenObjects,2))),0);
        //Action
        if(!isGrounded)
            {
                move += (gravity.normalized * fallSpeed);  
                if(dragZone == true)
                {
                    Zone = 1;
                    speed = acelerationSpeed.magnitude;
                    Debug.Log("Density " + Density);
                    Debug.Log("speed " + speed);
                    Debug.Log("Coeficient " + Coeficient);
                    Debug.Log("zone " + Zone);
                    
                    dragVector = (-0.5f * Density * Mathf.Pow(speed, 2) * Coeficient * Zone) * move;
                    Debug.Log("Drag vector" + dragVector);
                    //gameObject.transform.position += dragVector;
                    if(dragVector.magnitude >= move.magnitude)
                    {
                        move = (Vector3.zero);
                        move += (gravity.normalized * fallSpeed);
                    }
                    else
                    {
                        //gameObject.transform.position += (gravity.normalized * fallSpeed);
                        move += dragVector;
                        
                    }
                    Debug.Log("move " + move);
                }
            }
            theObject.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation;
            return;
    }

    void Friction()
    {
    }
    
    //Drag
    
    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "jelly")
        {
            Density = other.gameObject.GetComponent<GetDensity>().density;
            dragZone = true;
        }
    }
    public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "jelly")
        {
            dragZone = false;
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Planet")
        {
            isGrounded = true;
            FinalSpeed = 0;
            move = (Vector3.zero);
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Planet")
        {
            isGrounded = false;
            FinalSpeed = 0.1f;
            //move = Vector3.zero;
        }
    }

/*
    public void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,1f, planetLayerMask.value))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.left,0.5f, planetLayerMask.value))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.right,0.5f, planetLayerMask.value))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.up,1f, planetLayerMask.value))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else
        {
            isGrounded = false;
            return;
        }
    }*/


   
}
