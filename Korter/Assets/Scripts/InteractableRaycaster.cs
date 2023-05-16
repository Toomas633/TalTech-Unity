using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableRaycaster : MonoBehaviour
{
    public Transform raycastSource;

    public KeyCode toogleKey = KeyCode.E;

    private bool isInteractableRequester = false;

    public UnityEvent onInteractableDetached = new UnityEvent();
    public UnityEvent onInteractableLost = new UnityEvent();
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(toogleKey))
        {
            isInteractableRequester = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float raycastDistance = 2f;
        Ray ray = new Ray(raycastSource.position, raycastSource.forward);
        bool hitSomething = Physics.Raycast(ray, out RaycastHit hitResult, raycastDistance);

        if(hitSomething)
        {
            Collider hitCollider = hitResult.collider;
            GameObject hitObject = hitCollider.gameObject;

            Interactable hitInteractable = hitObject.GetComponentInParent<Interactable>();
            
            if(hitInteractable)
            {
                onInteractableDetached.Invoke();
                if(isInteractableRequester)
                {
                    hitInteractable.Interact();
                }
            }
            else
            {
                onInteractableLost.Invoke();
            }
        }
        else
        {
            onInteractableLost.Invoke();
        }

        isInteractableRequester = false;
    }
}
