using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NightmareStudio/Variable/Int")]
public class IntVariable : ScriptableObject
{
    public string DeveloperDecription;
    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }
}
