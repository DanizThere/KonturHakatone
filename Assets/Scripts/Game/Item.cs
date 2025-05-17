using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected bool _canInteract = false;
    public abstract void Interact();

    public void SetTrue() => _canInteract=true;
}
