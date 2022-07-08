using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public Transform objectPivot;
    public GameObject currentObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ClearInteractionObject();
        }
    }

    public void SetInteractionObject(Interactable interactionObject) {
        GameObject uiPrefab = Instantiate(interactionObject.UIPrefab, objectPivot.position, objectPivot.rotation, objectPivot) as GameObject;
        currentObject = uiPrefab;
        gameObject.SetActive(true);
    }

    public void ClearInteractionObject() {
        Destroy(currentObject);
        currentObject = null;
        gameObject.SetActive(false);
    }
}
