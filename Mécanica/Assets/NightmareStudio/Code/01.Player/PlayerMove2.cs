using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    
    public bool isGrounded;
    [SerializeField]float jumpForce;
    Vector3 verticalDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Movement()
    {

    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
        }
        gameObject.transform.position += (verticalDirection) * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jump = new Vector3 (0, jumpForce, 0);
            
            verticalDirection -= (jump);
        }
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
