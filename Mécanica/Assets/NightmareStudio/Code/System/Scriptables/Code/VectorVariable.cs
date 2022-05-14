using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStudio/Variable/Vector2")]
public class VectorVariable : ScriptableObject
{
    public string DeveloperDecription;
    public Vector2 Value;

    public void SetValue(Vector2 value)
    {
        Value = value;
    }
}
