using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IUsable
{
	public UnityEvent OnUse;
	public bool CanInteract
	{
		get { return canInteract; } set { canInteract = value; }
	}

	bool canInteract;
	public void Use()
	{
		if (OnUse != null)
		{
			OnUse.Invoke();
		}
	}
	public void OpenDoor()
    {
		print("");
    }
}
