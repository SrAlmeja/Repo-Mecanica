using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [HideInInspector]
    public Transform followObjective;
    private NavMeshAgent agent;
    private NormalState normalState;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        normalState = GetComponent<NormalState>();
    }

   public void NextWaypoint(Vector3 waypoint)
    {
        agent.destination = waypoint; 
        agent.Resume();
    }

    //Perseguira al jugador
    public void WaypointPlayer()
    {
        NextWaypoint(followObjective.position);
    }

    public void StopGuard()
    {
        agent.Stop();
    }

    public bool checkWaypoint()
    {
        return agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending;
    }
}
