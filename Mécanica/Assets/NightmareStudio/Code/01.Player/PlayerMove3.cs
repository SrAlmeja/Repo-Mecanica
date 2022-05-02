using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    private GravityPlanetFisics GPF;
    public GameObject player;

    public float movementSpeed;
    public float jumpForce;
    public float jumpLimit;
    [SerializeField] float moveVector;
    [SerializeField] float acelerationMove;
    Vector3 moveDirection;
    Vector3 verticalDirection;
    float elapsedTime;
    bool jumptime;


    void awake()
    {
        GravityPlanetFisics GPF = new GravityPlanetFisics();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        
    }

    void Jump()
    {
        /*fallSpeed -= 0.0981f * Time.deltaTime;
        Vector3 planetPos = new Vector3 (planets[closerPlanet].transform.position.x,planets[closerPlanet].transform.position.y,0);
        Vector3 playerPos = new Vector3 (player.transform.position.x,player.transform.position.y,0);
        Vector3 gravityDirection = new Vector3 ((playerPos.x - planetPos.x),(playerPos.y - planetPos.y),0);
        Vector3 gravity = new Vector3 (gravityDirection.x, gravityDirection.y, 0);*/

       // Vector3 PlanetPosition = new Vector3 (GPF.GravityFisics.planetPos.x, GPF.GravityFisics.planetPos.y, GPF.GravityFisics.planetPos.z);

    }
}
