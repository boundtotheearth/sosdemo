using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void OnInteractStart()
    {
        Debug.Log("INTERACT START: " + gameObject.name);
    }

    public virtual void OnInteract()
    {
        Debug.Log("INTERACT: " + gameObject.name);
    }

    public virtual void OnInteractEnd()
    {
        Debug.Log("INTERACT END: " + gameObject.name);
    }

    public virtual void OnHover()
    {
        Debug.Log("HOVERING: " + gameObject.name);
    }
}
