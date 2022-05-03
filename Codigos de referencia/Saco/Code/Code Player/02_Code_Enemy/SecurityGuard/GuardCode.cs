using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardCode : MonoBehaviour
{
	public float Timer;
	public List<Transform> _Waypoint;
	float elapsedTime;
	[SerializeField] BoolVariable WaypointSerch;

    void Update()
    {
		if (WaypointSerch == true)
        {
			//Debug.Log("Estoy buscando mi objetivo");
        }
		if (WaypointSerch == false)
		{
			Debug.Log("llegue al objetivo y ahora busco el siguiente");
		}
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= Timer)
        {
			MovetoPoint();
			elapsedTime = 0;
		}
		
    }

	void MovetoPoint()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		int randomIndex = Random.Range(0, _Waypoint.Count);
		agent.destination = _Waypoint[randomIndex].position;
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Toque algo");
		if (other.tag == "Waypoints")
		{
			Debug.Log("toque el waypoint");
		}
	}
}

