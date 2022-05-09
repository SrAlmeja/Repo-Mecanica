using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    [SerializeField] IntVariable Mass;
    [SerializeField] IntVariable Speed;
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
        Movement();
    }

    void Movement()
    {
        //Fuerza = Masa x Aceleración
        //Masa = Fuerza o gravedad / Aceleración
	    //Aceleración = (Velocidad f -Velocidad Inicial)/tiempo
	    //Velocidad
	    //Tiempo
    }
}
