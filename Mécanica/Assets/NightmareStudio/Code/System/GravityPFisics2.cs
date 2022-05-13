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
   public IntVariable mass2;
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
    //Aceleration
    [SerializeField]Vector2 acelerationSpeed;
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
        FinalSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //Masa
        mass = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
        //Peso de objetos
        weightObject =  new Vector2 ((mass.x * gravity.x), (mass.y * gravity.y));
        //Gravity
        if(isGrounded.Value == false)
            {
               gameObject.transform.position += (gravity.normalized * fallSpeed);
            }
            theObject.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation;
            return;
        //Ley de la Gravitacion universal
        //Vector2 gravityLaw = new Vector2 ((gravity.x*((mass.x*mass2.x))).x,().y);
    }

   
}
