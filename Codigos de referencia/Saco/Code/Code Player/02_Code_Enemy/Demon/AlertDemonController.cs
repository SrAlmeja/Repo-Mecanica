using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDemonController : MonoBehaviour
{
    private StateMachineDemonController stateMachineDemonController;
    private NavMeshController navMeshController;
    private VisionDemonController visionDemonController;

    public float SpeedRotation;
    public float SearchTime;
    float elapsedTime;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachineDemonController = GetComponent<StateMachineDemonController>();
        navMeshController = GetComponent<NavMeshController>();
        visionDemonController = GetComponent<VisionDemonController>();
    }

    void OnEnable()
    {
        navMeshController.StopGuard();
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, (SpeedRotation) * Time.deltaTime, 0f);
        elapsedTime += Time.deltaTime;
        RaycastHit hit;
        if (visionDemonController.WatchingThePlayer(out hit) && enabled)
        {
            navMeshController.followObjective = hit.transform;
            stateMachineDemonController.ActivationState(stateMachineDemonController.PersecutionDState);
            return;
        }
        else
        if (elapsedTime >= SearchTime)
        {
            stateMachineDemonController.ActivationState(stateMachineDemonController.NormalDState);
            return;
        }
    }
}
