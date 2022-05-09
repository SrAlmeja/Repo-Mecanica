using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCam : MonoBehaviour
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

    Mouse mouse;
    Camera mainCamera;

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
        }
        active = true;
        player = this.transform.parent.gameObject;
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
                CheckInputMouse();
            }
        }
    }

    public void FixedUpdate()
    {

    }

    void CheckInputMouse()
    {
        Vector2 mouseMovement = mouse.delta.ReadValue();
        if (!invertedYAxis)
        {
            mainCamera.transform.Rotate(mouseMovement.y * -1, 0, 0);
        }
        if (invertedYAxis)
        {
            mainCamera.transform.Rotate(mouseMovement.y, 0, 0);
        }

        player.transform.Rotate(0, mouseMovement.x, 0);

        if (mainCamera.transform.eulerAngles.x >= 0 && mainCamera.transform.eulerAngles.x <= 90)
        {
            mainCamera.transform.eulerAngles = new Vector3(Mathf.Clamp(mainCamera.transform.eulerAngles.x, 0, 90), player.transform.eulerAngles.y, 0);
        }
        else if (mainCamera.transform.eulerAngles.x <= 360 && mainCamera.transform.eulerAngles.x >= 270)
        {
            mainCamera.transform.eulerAngles = new Vector3(Mathf.Clamp(mainCamera.transform.eulerAngles.x, 270, 360), player.transform.eulerAngles.y, 0);
        }

        if (mouse.leftButton.isPressed)
        {
            GetViewInfo();
        }
    }

    void GetViewInfo()
    {
        RaycastHit hitInfo;
        Vector2 coordinate = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray myRay = mainCamera.ScreenPointToRay(coordinate);
        if (Physics.Raycast(myRay, out hitInfo, 100))
        {
            print(hitInfo.transform.name + " " + hitInfo.point);
        }
    }
}
