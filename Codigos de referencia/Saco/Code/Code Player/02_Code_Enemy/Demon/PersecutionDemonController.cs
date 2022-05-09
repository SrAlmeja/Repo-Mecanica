using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionDemonController : MonoBehaviour
{
    private StateMachineDemonController stateMachineDemonController;
    private NavMeshController navMeshController;
    private VisionDemonController visionDemonController;

    void Awake()
    {
        stateMachineDemonController = GetComponent<StateMachineDemonController>();
        navMeshController = GetComponent<NavMeshController>();
        visionDemonController = GetComponent<VisionDemonController>();
    }
    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(!visionDemonController.WatchingThePlayer(out hit, true))
        {
            stateMachineDemonController.ActivationState(stateMachineDemonController.AlertDState);
        }
        navMeshController.WaypointPlayer();
    }
}
