using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class GhostMovement : MonoBehaviour
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
    Gamepad gamePad;
    CharacterController characterController;
    GameObject theBooks, keys, Me;
    GameObject[] GP;

    private bool active;
    private Vector3 movementDirection;
    private Vector3 velocity;
    private Vector3 CamR;
    private Vector3 CamF;
    private float verticalSpeed;
    public float movementSpeed = 5f;
    public float gravity = 9.8f;
    public float jumpHeight = 1.0f;
    public string SceneToLoad;

    // StateMachine
    private MainCharacterStateMachine mainCharacterStateMachine;
    private CodeGhostSpawner codeGhostSpawner;

    void Prepare()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyBoard = Keyboard.current;
#endif
        gamePad = Gamepad.current;
        characterController = GetComponent<CharacterController>();
        active = true;
        GP = GameObject.FindGameObjectsWithTag("Particles");
        
    }

    public void Awake()
    {
        mainCharacterStateMachine = GetComponent<MainCharacterStateMachine>();

    }

    public void Start()
    {
        Prepare();
    }
    void Update()
    {
        if (active)
        {
            if (keyBoard != null)
            {
                if (theBooks == null) { CheckInputKeyBoard(); }
            }
        }
        theBooks = GameObject.FindGameObjectWithTag("Books");
        for (int i = 0; i < GP.Length; i++)
        {
            GP[i].SetActive(true);
        }
    }

    void CheckInputKeyBoard()
    {
        movementDirection = Vector3.zero;
        CamF = Camera.main.transform.forward;
        CamR = Camera.main.transform.right;
        CamF.y = 0;
        CamR.y = 0;
        CamF = CamF.normalized;
        CamR = CamR.normalized;
        if (keyBoard.wKey.isPressed)
        {
            movementDirection += CamF;
        }
        if (keyBoard.sKey.isPressed)
        {
            movementDirection -= CamF;
        }
        if (keyBoard.aKey.isPressed)
        {
            movementDirection -= CamR;
        }
        if (keyBoard.dKey.isPressed)
        {
            movementDirection += CamR;
        }
        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
            if (keyBoard.spaceKey.isPressed)
            {
                verticalSpeed = jumpHeight;
            }
        }
        verticalSpeed -= gravity * Time.deltaTime;
        movementDirection.y = verticalSpeed;
        movementDirection.Normalize();
        Move(movementDirection * Time.deltaTime);


        //Ghost Mechanics
        if (keyBoard.shiftKey.wasReleasedThisFrame)
        {
            
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Demons"))
        {
            SceneManager.LoadSceneAsync(SceneToLoad);
        }
    }

    void Move(Vector3 direction)
    {
        characterController.Move(direction * movementSpeed);
    }
}
