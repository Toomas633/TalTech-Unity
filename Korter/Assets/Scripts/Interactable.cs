using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool isActivated = false;
    public UnityEvent onInteractableActivated = new UnityEvent();
    public UnityEvent onInteractableDeactivated = new UnityEvent();

    // Update is called once per frame
    public void Interact()
    {
        if(isActivated)
        {
            onInteractableDeactivated.Invoke();
            isActivated = false;
        }
        else
        {
            onInteractableActivated.Invoke();
            isActivated = true;
        }
    }
}
