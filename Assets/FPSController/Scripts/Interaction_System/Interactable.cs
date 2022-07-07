using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material outlineMat;

    public virtual void OnInteractStart()
    {
        Debug.Log("INTERACT START: " + gameObject.name);
    }

    public virtual void OnInteract()
    {
        Debug.Log("INTERACTING: " + gameObject.name);
    }

    public virtual void OnInteractEnd()
    {
        Debug.Log("INTERACT END: " + gameObject.name);
    }

    public virtual void OnHoverStart()
    {
        Debug.Log("HOVER Start: " + gameObject.name);
        Renderer renderer = GetComponent<Renderer>();
        List<Material> materials = renderer.sharedMaterials.ToList();
        materials.Add(outlineMat);
        renderer.materials = materials.ToArray();
        
    }

    public virtual void OnHover()
    {
        Debug.Log("HOVERING: " + gameObject.name);
    }

    public virtual void OnHoverEnd()
    {
        Debug.Log("HOVER END: " + gameObject.name);
        Renderer renderer = GetComponent<Renderer>();
        List<Material> materials = renderer.sharedMaterials.ToList();
        materials.Remove(outlineMat);
        renderer.materials = materials.ToArray();
    }
}
