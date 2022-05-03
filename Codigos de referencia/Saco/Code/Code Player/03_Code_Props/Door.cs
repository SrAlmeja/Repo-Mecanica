using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IUsable
{
	[SerializeField] IntVariable keyNumber;
	public UnityEvent OnUse;
	public GameObject doors;
	public bool CanInteract
	{
		get { return canInteract; } set { canInteract = value; }
	}


	bool canInteract;
	public void Use()
	{
		Debug.Log("intentan abrir");
		if (OnUse != null)
		{
			OnUse.Invoke();
		}
	}

	public void OopenDoor()
    {
		if(keyNumber.Value >= 1)
        {
			doors.SetActive(false);
        }
    }
}
