using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUniversalGravity : MonoBehaviour
{
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
    public float finalSpeed;
    public float  initialSpeed;
    [SerializeField] float fallSpeed;
    public float fallSpeedController;
    [SerializeField] Vector3 acelerationSpeed;
    //Drag
    //CheckFlour
    [SerializeField] BooleanVariable isGrounded;
    
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

        //Saving gravity in a float
        gravityForce = Mathf.Sqrt (((Mathf.Pow(gravity.x, 2)) + ((Mathf.Pow(gravity.y, 2)))));
        Debug.Log("Gravityforce " + gravityForce);

        //Aceleration
        acelerationSpeed = new Vector3 (((finalSpeed-initialSpeed)/Time.deltaTime), ((finalSpeed-initialSpeed)/Time.deltaTime), 0);
        fallSpeed = (Mathf.Sqrt ((Mathf.Pow(acelerationSpeed.x, 2)) + (Mathf.Pow(acelerationSpeed.y, 2)))) * fallSpeedController;
        //fallSpeed = ((acelerationSpeed.x + acelerationSpeed.y)/2) * fallSpeedController;
        fallingObject = ((gravity.normalized * fallSpeed)*-1);

        // Gravity Action
        if(isGrounded.Value == false)
        {
            gameObject.transform.position += fallingObject;
        }
        //Rotation
        theObject.transform.rotation = Quaternion.FromToRotation(transform.up, gravity)* transform.rotation;
    }
}
