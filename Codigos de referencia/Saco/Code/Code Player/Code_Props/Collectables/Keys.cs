using UnityEngine;
using UnityEngine.Events;

public class Keys : MonoBehaviour, IUsable
{
    [SerializeField] IntVariable intKey;
    public GameObject GP1, GP2, GP3;

    public UnityEvent OnUse;
    public bool CanInteract
    {
        get {return canInteract;} set { canInteract = value; }
    }
    bool canInteract;
    public void Use()
    {
        if(OnUse != null)
        {
            OnUse.Invoke();
        }
        
    }

    public void getKey()
    {
        intKey.Value ++;
    } 
}
