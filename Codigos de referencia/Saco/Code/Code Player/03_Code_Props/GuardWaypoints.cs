using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWaypoints : MonoBehaviour
{
    [SerializeField] BoolVariable WaypointSerch;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("El guardia paso por aqui");
        WaypointSerch.SetValue(false);
        if (other.tag == "SecurityGuard")
        {
            Debug.Log("El guardia paso por aqui");
            WaypointSerch.SetValue  (false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("No hay Guardia");
        WaypointSerch.SetValue(true);
        if (other.tag == "SecurityGuard")
        {
            Debug.Log("No hay Guardia");
            WaypointSerch.SetValue(true);
        }
    }

}
