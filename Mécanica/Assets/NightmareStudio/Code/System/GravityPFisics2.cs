using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPFisics2 : MonoBehaviour
{
    //Gravity
   public GameObject[] planets;
   public GameObject theObject;
   float gravityForce;
   Vector3 planetPosition;
   Vector3 objectPosition;
   Vector3 gravity;
   public int mass;
   public IntVariable mass2;
    float AtractionForce1;
    float AtractionForce2;

    float closeDistance;
    int closerPlanet = 0;
    float planetDistance;
    //Aceleration
    [SerializeField]float aceleration;
    public float FinalSpeed;
    public float InitialSpeed;
   //CheckFloar
   [SerializeField] BooleanVariable isGrounded;
   //Rotation figure

   void awake()
   {
       
   }


    void Start()
    {
        InitialSpeed = 0.5f;
        aceleration = gravityForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GravitySystem()
    {
        //Distance
        Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y,0);
        Vector3 objectPos = new Vector3 (theObject.transform.position.x,theObject.transform.position.y,0);
        //Gravity Fisics
        Vector3 gravityDirection = new Vector3 ((objectPos.x - planetPos.x),(objectPos.y - planetPos.y),0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        

        // Aceleración = (Velocidad f -Velocidad Inicial)/tiempo 
        FinalSpeed = (aceleration + InitialSpeed) * Time.deltaTime;
        //En caso de planetas fuerza de atraccion]
    }

   
}
