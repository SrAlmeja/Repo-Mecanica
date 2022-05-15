using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{

    public GameObject player;
    private GravityUniversalGravity GUG;
    public float speed;
    float movingCharacter;
    float friction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        movingCharacter = Input.GetAxisRaw("Horizontal");
    }
    
    
    void Movement()
    {
        friction = this.gameObject.GetComponent<GravityUniversalGravity>().frictionVect.x;
        
        Debug.Log("Friction " + friction);
        if(friction > speed)
        {
            speed = 0;
        }
        else
        {
            speed = 20-friction;
            gameObject.transform.Translate (new Vector3 (movingCharacter, 0, 0) * speed *Time.deltaTime);
        }
         
    }
}
