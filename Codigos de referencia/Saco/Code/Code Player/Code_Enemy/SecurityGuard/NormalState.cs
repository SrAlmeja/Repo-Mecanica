using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalState : MonoBehaviour
{
    public List<Transform> Waypoints;
    private NavMeshController navMeshController;
    private StateMachineController stateMachineController;
    private int randomIndex;
    private VisionController visionController;
    public AudioSource GuardSound;
    

    void Awake()
    {
        stateMachineController = GetComponent<StateMachineController>();
        navMeshController = GetComponent<NavMeshController>();
        randomIndex = Random.Range(0, Waypoints.Count);
        visionController = GetComponent<VisionController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Buscara los waypoints
        if (navMeshController.checkWaypoint())
        {
            randomIndex = Random.Range(0, Waypoints.Count);
            NextWaypoint();
        }
        // Ve al juagador
        RaycastHit hit;
        if(visionController.WatchingThePlayer(out hit))
        {
            navMeshController.followObjective = hit.transform;
            stateMachineController.ActivationState(stateMachineController.PersecutionState);
            return;
        }
    }

     void OnEnable()
    {
        GuardSound.Play();
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
            stateMachineController.ActivationState(stateMachineController.AlertState);
        }
    }
}
