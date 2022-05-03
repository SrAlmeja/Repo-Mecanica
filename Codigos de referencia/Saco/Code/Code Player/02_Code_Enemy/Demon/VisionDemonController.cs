using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionDemonController : MonoBehaviour
{
    private NavMeshController navMeshController;

    public Transform Eyes;
    public float rangeVision = 20f;
    public Vector3 offset = new Vector3(0f, 0f, 0f); 

    // Start is called before the first frame update
    void Awake()
    {
        navMeshController = GetComponent<NavMeshController>();
    }

    public bool WatchingThePlayer(out RaycastHit hit, bool keepWatchingThePlayer = false)
    {
        Vector3 vectorDirection = Vector3.zero;
        if(keepWatchingThePlayer)
        {
            Debug.Log("veo al jugador");
            vectorDirection = (navMeshController.followObjective.position + offset) - Eyes.position;
        }
        else
        {
            Debug.Log("no veo al jugador");
            vectorDirection = Eyes.forward;
        }
        return Physics.Raycast(Eyes.position, vectorDirection, out hit, rangeVision) 
            && hit.collider.CompareTag("Player") 
            
            || Physics.Raycast(Eyes.position, vectorDirection, out hit, rangeVision)
            && hit.collider.CompareTag("SecurityGuard");
    }
}
