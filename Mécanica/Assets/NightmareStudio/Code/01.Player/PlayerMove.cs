using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    float jumpForce = 30;
    int jumpLimit;
    private PlayerControls _controls;
    private Vector3 theVector; 
    public bool isGrounded;
    float fallForce = -9.81f;

    void Awake() 
    {
        _controls = new PlayerControls();    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.position.magnitude);
        CheckFloar();
        fall();  
    }

    public void Jump (InputAction.CallbackContext context)
    {
        Vector3 jump = new Vector3 (0, jumpForce, 0);
        gameObject.transform.position += jump;
        Debug.Log("jumping >D");
    }

    public void Down (InputAction.CallbackContext context)
    {
        Vector3 jump = new Vector3 (0, jumpForce, 0);
        gameObject.transform.position -= jump;
        Debug.Log("AntiSaltanding");
    }

    void fall()
    {
        Vector3 falling = new Vector3(0,fallForce, 0); 
        if(!isGrounded)
        {
            gameObject.transform.position += falling * Time.deltaTime;
        }
        else
        {
             gameObject.transform.position += (falling * -1) * Time.deltaTime;
        }
    }

    void CheckFloar()
    {
        float previo;
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded = true;
            previo = fallForce;
            fallForce = 0;
        }
        else
        {
            fallForce = -9.81f;
            isGrounded = false;
        }
    }
}
