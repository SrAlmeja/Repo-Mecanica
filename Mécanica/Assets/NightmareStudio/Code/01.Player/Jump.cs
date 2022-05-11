using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] FloatVariable Gravity;
    [SerializeField] IntVariable Mass;
    public BooleanVariable IsGrounded;
    private GravityPlanetFisics gPF;

    void awake()
    {
        gPF = GetComponent<GravityPlanetFisics>();
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
