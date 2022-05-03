using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class CodeGhostSpawner : MonoBehaviour
{
    public GameObject playebleGhost;
    Keyboard keyBoard;
    GameObject myGhost;
    public UnityEvent OnSwitchGhost;
    public UnityEvent OnSwitchPlayer;
    float elapsedTime;
    public float liveTime;

    void Awake()
    {
        elapsedTime = 0;    
    }
    void Start()
    {
        keyBoard = Keyboard.current;
    }
    void Update()
    {
        Spawn();
        if (keyBoard.shiftKey.wasPressedThisFrame)
        {
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
        }
        if (keyBoard.shiftKey.wasReleasedThisFrame)
        {
            elapsedTime = 0;
            Debug.Log(elapsedTime);
        }
    }

    void Spawn()
    {
        if (keyBoard.shiftKey.wasPressedThisFrame)
        {
            myGhost = Instantiate(playebleGhost);
            if(OnSwitchGhost != null) { OnSwitchGhost.Invoke(); }
            Debug.Log("Invoca al fantasma");
            if (elapsedTime >= liveTime)
            {
                Destroy(myGhost);
                Debug.Log("El tiempo se acabo");
            }
        }
        if (keyBoard.shiftKey.wasReleasedThisFrame)
        {
            if (OnSwitchGhost != null) { OnSwitchPlayer.Invoke(); }
            Destroy(myGhost);
            Debug.Log("Destroy al fantasma");
        }
    }

}
