using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineDemonController : MonoBehaviour
{
    //Estados del guardia
    public MonoBehaviour NormalDState;
    public MonoBehaviour AlertDState;
    public MonoBehaviour PersecutionDState;
    public MonoBehaviour InitialDState;
    //Comportamiento actual del guardia
    private MonoBehaviour MyState;

    void Start()
    {
        ActivationState(InitialDState);
    }

    public void ActivationState(MonoBehaviour newState)
    {
        if (MyState != null) { MyState.enabled = false; }
        MyState = newState;
        MyState.enabled = true;
    }
}
