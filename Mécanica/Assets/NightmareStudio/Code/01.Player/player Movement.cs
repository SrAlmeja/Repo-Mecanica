using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
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
        keyBoard = Keyboard.current;
        gamepad = Gamepad.current;
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        Prepare();
    }

    void Update()
    {
        
    }

    void Jump()
    {
        if (characterController.isGrounded) 
        {
            fallForce = 0;
            elapsedTime = 1;
        }
        if (keyBoard.spaceKey.isPressed)
            {
                JumpForce = jumpTop;
            }
            if (JumpForce <= 2)
            {
                elapsedTime - 0.2
            }
    }

    void fall ()
    {
        fallForce = -9.81;
    }
}