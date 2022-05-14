using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlour : MonoBehaviour
{
    [SerializeField] BooleanVariable isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            isGrounded.Value = true;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.left,0.5f))
        {
            isGrounded.Value = true;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.right,0.5f))
        {
            isGrounded.Value = true;
        }
        else if(Physics.Raycast(gameObject.transform.position,Vector3.up,0.5f))
        {
            isGrounded.Value = true;
        }
        else
        {
            isGrounded.Value = false;
            return;
        }
    }
}
