using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Recives input and moves the main player
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement2 : MonoBehaviour
{
    #region Get&Set
    public bool Active
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
        }
    }
    #endregion

    Keyboard keyBoard;
    Gamepad gamepad;
    CharacterController characterController;
    GameObject theBooks, keys;

    private bool active;
    private Vector3 momentDirection;
    private Vector3 rightCamera;
    private Vector3 forwardCamera;
    private float certicalSpeed;
    public float gravity = 9.8f;
    public float jumpHeight = 1.0f;

    void Prepare()
    {
        #if UNITY_STANDALONE_WITH || UNITY_STANDAONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyBoard = Keyboard.current;
        #endif
        gamepad = Gamepad.current;
        characterController = GetComponent < CharacterController>();
        active = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
