using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFisics : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField]float fallSpeed;
    [SerializeField]bool isGrounded;
    Vector3 gravity;
=======
    float fallSpeed;
    public bool isGrounded;
    
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFloar();
        GravitySystem();
    }

    void GravitySystem()
    {
        fallSpeed -= 0.0981f * Time.deltaTime;
        Vector3 falling = new Vector3(0,fallSpeed, 0);
        if (!isGrounded)
        {   
            gameObject.transform.position += (falling);
        }
        else
        {fallSpeed = 0;}
    }

    void CheckFloar()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
