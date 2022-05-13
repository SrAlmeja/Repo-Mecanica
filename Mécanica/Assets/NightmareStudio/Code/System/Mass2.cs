using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStudio/Variable/Int")]
public class Mass2 : ScriptableObject
{
    public string DeveloperDecription;

    public float GravityForce;
    Vector2 acelerationSpeed;
    Vector2 gravity;
    Vector2 mass;

    public void SetValue()
    {
        mass = new Vector2 ((gravity.x/acelerationSpeed.x),(gravity.y/acelerationSpeed.y));
    }
}
