using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineController : MonoBehaviour
{
    //Estados del guardia
    public MonoBehaviour NormalState;
    public MonoBehaviour AlertState;
    public MonoBehaviour PersecutionState;
    public MonoBehaviour InitialState;
    //Comportamiento actual del guardia
    private MonoBehaviour MyState;

    void Start()
    {
        ActivationState(InitialState);
    }

    public void ActivationState(MonoBehaviour newState)
    {
        if (MyState != null) { MyState.enabled = false; }
        MyState = newState;
        MyState.enabled = true;

    }
}
