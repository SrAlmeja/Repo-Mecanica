using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionsSystem : MonoBehaviour
{
    [SerializeField]bool colisionUp, colisionDown, colisionRight, colisionLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontTouchTheChild();
    }

    void DontTouchTheChild()
    {
        if(Physics.Raycast(gameObject.transform.position,Vector3.up,0.5f))
        {
            colisionUp = true;
            Vector3 up = new Vector3(0,0, 0);
        }
        else
        {
            colisionUp = false;
        }
        if(Physics.Raycast(gameObject.transform.position,Vector3.down,0.5f))
        {
            colisionDown = true;
        }
        else
        {
            colisionDown = false;
        }
        if(Physics.Raycast(gameObject.transform.position,Vector3.right,0.5f))
        {
            colisionRight = true;
        }
        else
        {
            colisionRight = false;
        }
        if(Physics.Raycast(gameObject.transform.position,Vector3.left,0.5f))
        {
            colisionLeft = true;
        }
        else
        {
            colisionLeft = false;
        }
    }
}
