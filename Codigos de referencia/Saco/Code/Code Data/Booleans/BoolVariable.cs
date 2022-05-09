using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStudio/Variable/bool")]
public class BoolVariable : ScriptableObject
{
    public string DeveloperDecription;
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
