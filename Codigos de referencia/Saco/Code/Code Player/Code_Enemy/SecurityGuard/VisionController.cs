using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionController : MonoBehaviour
{
    public Transform Eyes;
    public float rangeVision = 20f;
    
    //Establecer que tan alto vemos al jugador
    public Vector3 offset = new Vector3(0f, 0f, 0f);
    
    //Hacer referencia al NavMeshCopntroller
    private NavMeshController navMeshController;

    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }

    public bool WatchingThePlayer(out RaycastHit hit, bool keepWatchingThePlayer = false)
    {
        Vector3 vectorDirection;
        if (keepWatchingThePlayer) 
        {
            //Seguir con la mirada al jugador
            vectorDirection = (navMeshController.followObjective.position + offset) - Eyes.position; 
        } 
        else
        {
            //Ver al frnte
            vectorDirection = Eyes.forward;
        }

        return Physics.Raycast(Eyes.position, Eyes.forward, out hit, rangeVision) 
        && hit.collider.CompareTag ("Player");
    }
}
