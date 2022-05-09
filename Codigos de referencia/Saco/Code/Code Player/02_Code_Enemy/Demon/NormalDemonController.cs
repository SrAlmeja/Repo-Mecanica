using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalDemonController : MonoBehaviour
{
    public List<Transform> Waypoints;
    private NavMeshController navMeshController;
    private StateMachineDemonController stateMachineDemonController;
    private VisionDemonController visionDemonController;
    private int randomIndex;

    
    


    void Awake()
    {
        stateMachineDemonController = GetComponent<StateMachineDemonController>();
        navMeshController = GetComponent<NavMeshController>();
        randomIndex = Random.Range(0, Waypoints.Count);
        visionDemonController = GetComponent<VisionDemonController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(visionDemonController.WatchingThePlayer(out hit))
        {
            navMeshController.followObjective = hit.transform;
            stateMachineDemonController.ActivationState(stateMachineDemonController.AlertDState);
            return;
        }

        if (navMeshController.checkWaypoint())
        {
            randomIndex = Random.Range(0, Waypoints.Count);
            NextWaypoint();
        }
    }

    void OnEnable()
    {
        navMeshController.NextWaypoint(Waypoints[randomIndex].position);
    }

    void NextWaypoint()
    {
        navMeshController.NextWaypoint(Waypoints[randomIndex].position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stateMachineDemonController.ActivationState(stateMachineDemonController.AlertDState);
        }
        if (other.gameObject.CompareTag("SecurityGuard"))
        {
            stateMachineDemonController.ActivationState(stateMachineDemonController.AlertDState);
        }
    }
}
