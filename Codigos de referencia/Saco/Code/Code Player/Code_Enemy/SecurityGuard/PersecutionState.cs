using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionState : MonoBehaviour
{
    private StateMachineController stateMachineController;
    private NavMeshController navMeshController;
    private VisionController visionController;

    void Awake()
    {
        stateMachineController = GetComponent<StateMachineController>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }
    void OnEnable()
    {
        
    }


    void Update()
    {
        RaycastHit hit;
        if(!visionController.WatchingThePlayer(out hit, true))
        {
            stateMachineController.ActivationState(stateMachineController.AlertState);
        }
        navMeshController.WaypointPlayer();
    }
}
