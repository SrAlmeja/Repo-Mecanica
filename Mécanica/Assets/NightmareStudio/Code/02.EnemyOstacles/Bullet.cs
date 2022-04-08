using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    Vector3 moveDirection;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        //transform.Translate(new Vector3(speed,0,0));
        
        Vector3 move = new Vector3 (speed,0,0);
        moveDirection += (move) * Time.deltaTime;
        gameObject.transform.position += (moveDirection)* Time.deltaTime;
        //Destroy(gameObject, 5);
    }

}
