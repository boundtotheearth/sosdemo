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

    }

    public virtual void OnInteract()
    {

    }

    public virtual void OnInteractEnd()
    {
        if(canTake)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void OnHoverStart()
    {
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
        
    }

    public virtual void OnHoverEnd()
    {
        Renderer renderer = GetComponent<Renderer>();
        List<Material> materials = renderer.sharedMaterials.ToList();
        if(materials.Contains(outlineMat))
        {
            materials.Remove(outlineMat);
        }
        renderer.materials = materials.ToArray();
    }
}
