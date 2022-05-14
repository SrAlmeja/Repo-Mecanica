using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUniversalGravity : MonoBehaviour
{
    //GravitySystem
    //PlanetDetection
    public GameObject[] planets;
    public GameObject theObject;
    float closeDistance;
    int closerPlanet = 0;
    float planetDistance;

    //Aceleration
    //Drag
    //CheckFlour
    
    void Update() 
    {
        ObjectsDistance();
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

    void GravityFisics()
    {
        //Distance
        Vector2 planetPos = new Vector2 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y);
        Vector2 objectPos = new Vector2 (theObject.transform.position.x,theObject.transform.position.y);
        //Fall Direction
        Vector2 gravityDirection = new Vector2 ((objectPos.x - planetPos.x),(objectPos.y - planetPos.y));
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
    }
}
