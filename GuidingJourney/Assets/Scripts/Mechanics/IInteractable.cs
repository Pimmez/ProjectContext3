using UnityEngine;
public interface IInteractable
{
    void Interact(GameObject _location);
}

/*
interactable = newCollider.GetComponent<IInteractable>();
interactable.Interact(newLocation);
*/