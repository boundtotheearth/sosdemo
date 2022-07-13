using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material outlineMat;
    public ClueData clueData;
    public bool canTake;

    // Workaround for prefab self referencing
    public virtual void Start()
    {
        OnHoverEnd();
    }

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
        if(canTake)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void OnHoverStart()
    {
        Debug.Log("HOVER Start: " + gameObject.name);
        Renderer renderer = GetComponent<Renderer>();
        List<Material> materials = renderer.sharedMaterials.ToList();
        if(!materials.Contains(outlineMat))
        {
            materials.Add(outlineMat);
        }
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
        if(materials.Contains(outlineMat))
        {
            materials.Remove(outlineMat);
        }
        renderer.materials = materials.ToArray();
    }
}
