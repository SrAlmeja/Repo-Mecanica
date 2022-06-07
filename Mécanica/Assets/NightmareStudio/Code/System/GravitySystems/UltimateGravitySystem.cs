using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateGravitySystem : MonoBehaviour
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
    
    //Colission,

    // Start is called before the first frame update
    void Start()
    {
        /*hola desde el telado c:
        tqnm
        :3
        buena suerte en tu semestre angelito TU PUEDEEES CREO EN TI 
        ATT. Dino.*/
    }

    void Update() 
    {
        
    }

    void UpandDownGravity()
    {
        
    }

  
}
