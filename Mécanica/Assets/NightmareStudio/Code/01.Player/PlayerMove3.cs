using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    public GameObject player;
    public int speed;
    Vector3 movingCharacter;
    public float jump;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        gameObject.transform.Translate(movingCharacter);
    }
    
    
    void Movement()
    {
         
         if (Input.GetKey(KeyCode.D))
         {
            movingCharacter = new Vector3 ((gameObject.transform.position.x + 1 * Time.deltaTime),0,0);
         }
         if (Input.GetKey(KeyCode.A))
         {
             movingCharacter = new Vector3 ((gameObject.transform.position.x + 1 * Time.deltaTime),0,0);
        }
    }
    
}
