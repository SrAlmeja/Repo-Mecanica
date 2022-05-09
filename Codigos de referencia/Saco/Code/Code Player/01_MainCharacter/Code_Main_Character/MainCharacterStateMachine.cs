using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MainCharacterStateMachine : MonoBehaviour
{
    public UnityEvent OnSwitchGhost;
    public UnityEvent OnSwitchPlayer;
    Keyboard keyBoard;

    void Update()
    {
        
    }


    void ActivateScrtipt()
    {
        if (keyBoard.shiftKey.wasPressedThisFrame)
        {
            if (OnSwitchGhost != null) { OnSwitchGhost.Invoke(); }
        }
    }

    void DesactivateScript()
    {
        if (keyBoard.shiftKey.wasReleasedThisFrame)
        {
            if (OnSwitchGhost != null) { OnSwitchPlayer.Invoke(); }
        }
    }
    
}
