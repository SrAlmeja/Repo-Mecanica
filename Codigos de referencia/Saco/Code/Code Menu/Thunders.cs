using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunders : MonoBehaviour
{
    float thunderSpeed = 0.07f;
    int randomizer = 0;
    GameObject light;


    private void Update()
    {
        Thunder();
    }

    IEnumerator Thunder()
    {
        while (true)
        {
            if (randomizer == 0)
            {
                light.active = true;
            }
            else light.active = false;

            randomizer = Random.Range(0, 1);

            yield return new WaitForSeconds(thunderSpeed);
        }
    }
}
