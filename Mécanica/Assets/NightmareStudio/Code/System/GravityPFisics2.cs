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
   Vector2 gravity;
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
   public float InitialSpeed;
   //CheckFloar
   //[SerializeField] BooleanVariable isGrounded;
   bool isGrounded;
   //Segunda prueba
   public float fallSpeed2;

   void awake()
   {
       
   }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GravitySystem();
        isGrounded = false;
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
        mass = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
        //Peso de objetos
        weightObject =  new Vector2 ((mass.x * gravity.x), (mass.y * gravity.y));
        //Gravity
        distanceBetweenObjects =((gravityDirection.x + gravityDirection.y)/2);
        //Ley de la Gravitacion universal
        Vector3 gravityLaw = new Vector3 ((gravity.x*((mass.x*mass2.Value.x))/(Mathf.Pow(distanceBetweenObjects,2))),(gravity.y*((mass.y*mass2.Value.y))/(Mathf.Pow(distanceBetweenObjects,2))),0);
        //Action
        if(!isGrounded)
            {
               gameObject.transform.position += (gravity.normalized * fallSpeed);
            }
            theObject.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation;
            return;

    
    }

   
}
