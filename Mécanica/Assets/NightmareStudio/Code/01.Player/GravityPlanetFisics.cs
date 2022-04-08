using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlanetFisics : MonoBehaviour
{  
    //Gravity 
    public GameObject player;
   public GameObject[] planets;
   Vector3 planetPosition;
   Vector3 PlayerPosition;
   [SerializeField] float gravityForce;
   public float planetMass;
   public float objectMass;
   Vector3 gravityLaw;
   float distanceX;
   float distanceY;
   float masses;

   //CheckFloar
   public bool isGrounded;



    // Update is called once per frame
    void Update()
    {
        CheckFloar();
        GravityFisics();
    }


    void GravityFisics()
    {
        gravityForce = -9.81f * Time.deltaTime;
        masses = objectMass*planetMass;
        Vector3 planetPos = new Vector3 (planets[0].transform.position.x,planets[0].transform.position.y,0);
        Vector3 playerPos = new Vector3 (player.transform.position.x,player.transform.position.y,0);
        Vector3 objDist = new Vector3 ((playerPos.x -planetPos.x),(playerPos.y -planetPos.y),0);
        Vector3 ObjectDistance2= new Vector3 ((objDist.x*objDist.x),(objDist.y*objDist.y),0);
        Vector3 MassAndDistance = new Vector3 (masses/(ObjectDistance2.x), masses/(ObjectDistance2.y), 0);
        gravityLaw = gravityForce * MassAndDistance;
        if(!isGrounded)
        {
            gameObject.transform.position = gravityLaw;
        }
        player.transform.rotation = Quaternion.FromToRotation(transform.up, gravityLaw) * transform.rotation;
    }

    void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
            gravityForce=0;
        }
        else
        {
            isGrounded = false;
        }
    }
}
