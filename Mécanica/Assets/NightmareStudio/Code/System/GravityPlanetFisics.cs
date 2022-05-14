using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlanetFisics : MonoBehaviour
{  
    //Gravity 
    public GameObject player;
   public GameObject[] planets;
   float fallSpeed;
   Vector3 planetPosition;
   Vector3 PlayerPosition;
   public Vector3 gravity;
   //CheckFloar
   public bool isGrounded;
   //Planets Distance
    float closeDistance;
    int closerPlanet = 0;
    float planetDistance;
   
    void Update()
    {
        //Checking the closer planet
        closeDistance = Vector3.Distance(transform.position, planets[0].transform.position);    
        for(int i = 0; i<planets.Length; i++)
        {
            planetDistance = Vector3.Distance(transform.position, planets[i].transform.position);
            if (planetDistance <= closeDistance) {closeDistance = planetDistance; closerPlanet = i;}
            Debug.Log("Closer Planet " + closerPlanet);
        }
        //CheckFloar();
        GravityFisics();
        //Quitar este al terminar el dragg
        isGrounded = false;
    }

    public void GravityFisics()
    {
        //Gravity Fisics
        fallSpeed -= 0.0981f * Time.deltaTime;
        Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y,0);
        Vector3 playerPos = new Vector3 (player.transform.position.x,player.transform.position.y,0);
        Vector3 gravityDirection = new Vector3 ((playerPos.x - planetPos.x),(playerPos.y - planetPos.y),0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        

        if(!isGrounded)
        {
            gameObject.transform.position += (gravity.normalized * fallSpeed);
        }
        player.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation; 
        return;
    }
    

    public void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,1f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.left,0.5f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.right,0.5f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.up,1f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else
        {
            isGrounded = false;
            return;
        }
    }
}
