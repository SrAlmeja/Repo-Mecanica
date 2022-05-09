using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStudio/Variable/Float")]
public class FloatVariable : ScriptableObject
{
    public string DeveloperDecription;
    public float Value;

    public void SetValue (float value)
    {
        Value = value;
    }
}
