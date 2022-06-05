using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsRotation : MonoBehaviour
{
    float rotateToX, rotateToY, rotateToZ;
    public int speedRotationX, speedRotationY, speedRotationZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateToX += Time.deltaTime * speedRotationX;
        rotateToY += Time.deltaTime * speedRotationY;
        rotateToZ += Time.deltaTime * speedRotationZ;
        transform.rotation = Quaternion.Euler(rotateToX,rotateToY,rotateToZ);
    }
}
