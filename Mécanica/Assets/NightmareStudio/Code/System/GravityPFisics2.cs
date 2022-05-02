using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPFisics2 : MonoBehaviour
{
     //Gravity
    public GameObject player;
   public GameObject[] planets;
   float fallSpeed;
   Vector3 planetPosition;
   Vector3 PlayerPosition;
   Vector3 gravity;
   //CheckFloar
   public bool isGrounded;
   //Rotation figure

   


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFloar();
        GravityFisics();
    }


    void GravityFisics()
    {
        fallSpeed -= 0.0981f * Time.deltaTime;
        Vector3 planetPos = new Vector3 (planets[0].transform.position.x,planets[0].transform.position.y,0);
        Vector3 playerPos = new Vector3 (player.transform.position.x,player.transform.position.y,0);
        Vector3 gravityDirection = new Vector3 ((playerPos.x - planetPos.x),(playerPos.y - planetPos.y),0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);
        if(!isGrounded)
        {
            gameObject.transform.position += (gravity * fallSpeed);
        }
        player.transform.rotation = Quaternion.FromToRotation(transform.up, gravity) * transform.rotation;
    }

    void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
            fallSpeed=0;
        }
        else
        {
            isGrounded = false;
        }
    }
}
