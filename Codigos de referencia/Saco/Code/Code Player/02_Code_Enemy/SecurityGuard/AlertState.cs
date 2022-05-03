using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{
    public float SpeedRotation;
    public float SearchTime;
    float elapsedTime;
    private StateMachineController stateMachineController;
    private NavMeshController navMeshController;
    private VisionController visionController;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachineController = GetComponent<StateMachineController>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable()
    {
        navMeshController.StopGuard();
        elapsedTime = 0;
    }


    void Update()
    {
        
        Debug.Log("Estoy alerta");
        transform.Rotate(0f, (SpeedRotation) * Time.deltaTime, 0f);
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= SearchTime)
        {
            stateMachineController.ActivationState(stateMachineController.NormalState);
            return;
        }

        RaycastHit hit;
        if (visionController.WatchingThePlayer(out hit) && enabled)
        {
            navMeshController.followObjective = hit.transform;
            stateMachineController.ActivationState(stateMachineController.PersecutionState);
            return;
        }

    }
}
