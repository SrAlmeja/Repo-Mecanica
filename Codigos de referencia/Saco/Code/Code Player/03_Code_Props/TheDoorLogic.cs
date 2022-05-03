using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoorLogic : MonoBehaviour
{
    [SerializeField] IntVariable keyNumber;
    public GameObject theDoor, doors;

    // Start is called before the first frame update
    void Start()
    {
        keyNumber.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (keyNumber.Value == 1)
        {
            doors.SetActive(false);
        }
        //if (keyNumber.Value == 3)
        {
            theDoor.SetActive(false);
        }
    }
}
