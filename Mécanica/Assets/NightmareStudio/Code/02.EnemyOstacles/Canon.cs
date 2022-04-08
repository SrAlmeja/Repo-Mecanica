using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject CanonBullets;
    public Transform canonFace;
    public float spawnTime;
    float currentSpawnTime;
    public float  NumberBullet;
    private Vector3 initialSpeed;
    

    void Start()
    {
        currentSpawnTime = spawnTime;
    }

    void Update()
    {
        Timer();
    }
    void Timer()
    {
        if(currentSpawnTime >= 0)
        {
            currentSpawnTime -= Time.deltaTime;
        }
        else
        { 
            Fire();
            currentSpawnTime = 6;
            
        }
    }

    void Fire()
    {
        GameObject bullets = Instantiate(CanonBullets, canonFace.position, Quaternion.identity);
        bullets.transform.Translate (initialSpeed);
    }
}
