using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStudio/Scripts/GravityPlanetSystem")]
public class ScriptableGravity : ScriptableObject
{
    //Gravity
   public GameObject[] planets;
   public GameObject theObject;
   float gravityForce;
   Vector2 planetPosition;
   Vector2 objectPosition;
   Vector2 gravity;
   Vector2 mass;
   Vector2 mass2;
   float AtractionForce1;
   float AtractionForce2;
   float closeDistance;
   int closerPlanet = 0;
   float planetDistance;
   [SerializeField]Vector2 weightObject;
   [SerializeField] Vector2 gravityLaw;
   Vector2 Object1Position;
   Vector2 Object2Position;
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
        Vector2 gravityDirection = new Vector3 ((objectPos.x - planetPos.x),(objectPos.y - planetPos.y));
        Vector2 gravity = new Vector2 (gravityDirection.x, gravityDirection.y);
        //Aceleration
        acelerationSpeed = new Vector2 (((FinalSpeed-InitialSpeed)/Time.deltaTime), ((FinalSpeed-InitialSpeed)/Time.deltaTime));
        //Masa
        mass = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
        mass2 = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
        //Peso de objetos
        weightObject =  new Vector2 ((mass.x * gravity.x), (mass.y * gravity.y));
        //Ley de la Gravitacion universal
        //Vector2 gravityLaw = new Vector2 ((gravity.x*((mass.x*mass2.x))).x,().y);
    }

   
}

