using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Keyboard keyBoard;
    Gamepad gamepad;
    CharacterController characterController;
    
    private Vector2 movementDirection;
    private float startSpeed;
    private float runAceleration;
    private float JumpForce;
    private double fallForce;
    private double jumpDesaceleration;
    public Transform floarChecking;
    public float maxspeed;
    public float jumpTop;
    public float elapsedTime;



    void Prepare()
    {
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        #endif
        var keyBoard = KeyBoard.current;
        var gamepad = Gamepad.current;
        
        if (keyBoard == null)
        return;
    }
    void Start()
    {

    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (keyBoard.akey.waspressedThisFrame)
        {
            debug.Log("Derecha");
        }
        else if (keyBoard.dkey.waspressedThisFrame)
        {
            debug.Log ("Izquierda");
        }
    }
    void Jump()
    {
        if (characterController.isGrounded) 
        {
            fallForce = 0;
            Debug.Log("jump");
        }
        if (keyBoard.spaceKey.isPressed)
            {
                JumpForce = jumpTop;
            }
            if (JumpForce <= 2)
            {
                elapsedTime - 0.2;
            }
    }

    void fall ()
    {
        fallForce = -9.81;
    }
}