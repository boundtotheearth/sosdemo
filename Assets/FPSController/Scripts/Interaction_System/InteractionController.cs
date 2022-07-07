using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float rayDistance = 0f;
    [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayer = ~0;


    private Camera myCamera;

    private bool isInteracting = false;
    
    private Interactable hoveredInteractable = null;

    void Awake()
    {
        myCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckForInteractable();

        if(hoveredInteractable != null)
        {
            hoveredInteractable.OnHover();
            if(isInteracting)
            {
                hoveredInteractable.OnInteract();
            }
        }
        
        
    }


    void CheckForInteractable()
    {
        Ray ray = new Ray(myCamera.transform.position, myCamera.transform.forward);
        RaycastHit hitInfo;

        bool hitSomething = Physics.SphereCast(ray, raySphereRadius, out hitInfo, rayDistance, interactableLayer);
        bool foundInteractable = false;
        if(hitSomething)
        {
            Interactable interactable = hitInfo.transform.GetComponent<Interactable>();

            if(interactable != null)
            {
                
                if(interactable != hoveredInteractable)
                {
                    interactable.OnHoverStart();
                }
                hoveredInteractable = interactable;
                foundInteractable = true;
            }
        }

        if(!foundInteractable && hoveredInteractable != null)
        {
            hoveredInteractable.OnHoverEnd();
            hoveredInteractable = null;
        }

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, hitSomething ? Color.green : Color.red);
    }

    public void OnInteractStart()
    {
        isInteracting = true;
        hoveredInteractable.OnInteractStart();
    }

    public void OnInteractEnd()
    {
        hoveredInteractable.OnInteractEnd();
        isInteracting = false;
    }
}
