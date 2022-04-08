using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserPlanet : MonoBehaviour
{
    GravityPlanetFisics GPF;
    public float closeDistance;
    // Start is called before the first frame update
    void Awake() 
    {
        GPF=GetComponent<GravityPlanetFisics>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       closeDistance = Vector3.Distance(Transform.position, )
    }
}
