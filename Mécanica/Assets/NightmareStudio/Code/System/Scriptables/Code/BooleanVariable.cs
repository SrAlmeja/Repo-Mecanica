using UnityEngine;

[CreateAssetMenu(menuName = "NightmareStudio/Variable/Booleans")]
public class BooleanVariable : ScriptableObject
{
    public string DeveloperDescriotion;
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
