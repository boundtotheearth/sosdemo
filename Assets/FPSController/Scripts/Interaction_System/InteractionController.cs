using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private float rayDistance = 0f;
    [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayer = ~0;
    [SerializeField] private ExamineUI examineUI;
    [SerializeField] private GameManager gameManager;


    private Camera myCamera;

    [SerializeField] private bool isInteracting = false;
    
    [SerializeField] private Interactable hoveredInteractable = null;
    [SerializeField] private Interactable interactingObject = null;
    [SerializeField] private GameObject examineObject = null;
    [SerializeField] private Transform focusPoint;
    public float focusSpeed = 10f;

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
                // Hovering over a new object
                if(interactable != hoveredInteractable)
                {
                    interactable.OnHoverStart();

                    // Was already hovering on shomething else
                    if(hoveredInteractable != null)
                    {
                        hoveredInteractable.OnHoverEnd();
                    }
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

    public void ToggleInteract() {
        if(!isInteracting) {
            OnInteractStart();
        } else {
            OnInteractEnd();
        }
    }

    private void OnInteractStart()
    {
        if(hoveredInteractable != null)
        {
            isInteracting = true;
            interactingObject = hoveredInteractable;
            interactingObject.OnInteractStart();
            examineUI.SetExamineObject(interactingObject.clueData);
            gameManager.CollectClue(interactingObject.clueData);
            GetComponent<InputHandler>().DisableCameraInput();
            GetComponent<InputHandler>().DisableMovementInput();
            examineObject = Instantiate(interactingObject.clueData.cluePrefab, interactingObject.transform.position, interactingObject.transform.rotation, focusPoint.transform) as GameObject;
            StartCoroutine(FocusObject());
            interactingObject.gameObject.SetActive(false);
        }
    }

    private void OnInteractEnd()
    {
        if(interactingObject != null)
        {
            interactingObject.OnInteractEnd();
            isInteracting = false;
            examineUI.SetExamineObject(interactingObject.clueData);
            GetComponent<InputHandler>().EnableCameraInput();
            GetComponent<InputHandler>().EnableMovementInput();
            StartCoroutine(UnfocusObject());
        }
    }

    public IEnumerator FocusObject() 
    {
        float interp = 0;
        for(;;)
        {
            Debug.Log(interp);
            if(interp < 1f) {
                interp += Time.deltaTime * focusSpeed;
            } else {
                break;
            }
            examineObject.transform.position = Vector3.Lerp(interactingObject.transform.position, focusPoint.position, interp);
            examineObject.transform.rotation = Quaternion.Lerp(interactingObject.transform.rotation, focusPoint.rotation, interp);
            yield return null;
        }
    }

    public IEnumerator UnfocusObject()
    {
        float interp = 0;
        Vector3 initialPos = examineObject.transform.position;
        Quaternion initialRot = examineObject.transform.rotation;
        for(;;)
        {
            if(interp < 1f) {
                interp += Time.deltaTime * focusSpeed;
            } else {
                break;
            }
            examineObject.transform.position = Vector3.Lerp(initialPos, interactingObject.transform.position, interp);
            examineObject.transform.rotation = Quaternion.Lerp(initialRot, interactingObject.transform.rotation, interp);
            yield return null;
        }

        interactingObject.gameObject.SetActive(true);
        Destroy(examineObject);
        examineObject = null;
    }
}
