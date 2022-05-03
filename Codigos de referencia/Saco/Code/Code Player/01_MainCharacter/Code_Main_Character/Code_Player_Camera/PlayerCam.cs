using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCam : MonoBehaviour
{
    public LayerMask layers;
    Mouse mouse;
    Keyboard keyboard;
    [SerializeField] Camera myCamera;
    float rotationLimit = 0f;
    float rotationX = 0f;

    [SerializeField] FloatVariable speedCamera;
    [SerializeField] BoolVariable invertedYBool;
    [SerializeField] BoolVariable invertedXBool;
    bool invertedXAxis;
    [SerializeField] private Transform transformPlayer;

   

    Camera mainCamera;
    public Camera ghostCamera;
    public Camera normalCamera;
    //books & keys
    public float keyCounter;
    GameObject theLetter, keys, TheDoor;

    public cameraState state;
    public enum cameraState
    {
        Static, Moving
    }

    public void Start()
    {
        Prepare();
    }

    public void Update()
    {
        if (active)
        {
            if (mouse != null && mainCamera != null)
            {
                if (state == cameraState.Moving)
                {
                    CheckMouseInput();
                    BlockCamera();
                }
                else if (state == cameraState.Static)
                {
                    UnblockedCamera();
                }
            }
        }
        //theLetter = GameObject.FindGameObjectWithTag("Books");

        keyboard = Keyboard.current;
        
        if (keyboard.shiftKey.wasPressedThisFrame)
        {
            if (ghostCamera != null) { ghostCamera.enabled = true; }
            
            normalCamera.enabled = false;
        }
        if (keyboard.shiftKey.wasReleasedThisFrame)
        {
            if (ghostCamera != null) { ghostCamera.enabled = false; }
            
            normalCamera.enabled = true;
        }
    }

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
    public bool InvertedXAxis
    {
        get
        {
            return invertedXAxis;
        }
        set
        {
            invertedXAxis = value;
        }
    }
    public bool InvertedYAxis
    {
        get
        {
            return invertedYAxis;
        }
        set
        {
            invertedYAxis = value;
        }
    }
    #endregion

    [SerializeField] private bool invertedYAxis;
    private GameObject player;
    private bool active;
    void Prepare()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        mouse = Mouse.current;
#endif
        try
        {
            mainCamera = Camera.main;
        }
        catch
        {
            mainCamera = GetComponent<Camera>();
            ghostCamera = GetComponent<Camera>();
        }
        active = true;
        player = this.transform.parent.gameObject;
    }


    void CheckMouseInput()
    {
        Vector2 mouseMovement = mouse.delta.ReadValue();
        rotationX = mouseMovement.x * speedCamera.Value;
        rotationLimit += mouseMovement.y * speedCamera.Value;
        rotationLimit = Mathf.Clamp(rotationLimit, -80, 80f);

        //Check the value on the scriptableObject in Y bool 
        if (invertedYBool != null)
        {
            invertedYAxis = invertedYBool.Value;
        }
        //Check the value on the scriptableObject in X bool 
        if (invertedXBool != null)
        {
            invertedXAxis = invertedXBool.Value;
        }
        // Y camera no inverted
        if (!invertedYAxis)
            mainCamera.transform.localRotation = Quaternion.Euler(rotationLimit * -1, 0, 0);
        // Y camera inverted
        if (invertedYAxis)
            mainCamera.transform.localRotation = Quaternion.Euler(rotationLimit * 1, 0, 0);
        //X camera no inverted
        if (!invertedXAxis)
            transformPlayer.Rotate(Vector3.up * rotationX);
        //X camera inverted
        if (invertedXAxis)
            transformPlayer.Rotate(Vector3.up * rotationX * -1);

        //Check Click to interact
        if (mouse.leftButton.wasPressedThisFrame)
        {
            GetViewInfo();
        }

    }
    void GetViewInfo()
    {
        RaycastHit hitInfo;
        Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray myRay = mainCamera.ScreenPointToRay(coordinate);
        if (Physics.Raycast(myRay, out hitInfo, 100, layers))
        {
            print(hitInfo.transform.name + " " + hitInfo.point);
            IUsable usable = hitInfo.collider.transform.GetComponent<IUsable>();
            if(usable != null)
            {
                usable.Use();
                ChangeStaticCameraState;
            }
        }
    }
    private void BlockCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void UnblockedCamera()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    public void ChangeStaticCameraState()
    {
        state = cameraState.Static;
    }

    public void ChangeNormalCameraState()
    {
        state = cameraState.Moving;
    }
}
