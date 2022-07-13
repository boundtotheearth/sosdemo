using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineUI : MonoBehaviour
{
    public Transform objectPivot;
    public GameObject currentObject;
    public CluesUI cluesUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            ClearExamineObject();
        }
    }

    public void SetExamineObject(ClueData clueData) {
        GameObject uiPrefab = Instantiate(clueData.cluePrefab, objectPivot.position, objectPivot.rotation, objectPivot) as GameObject;
        currentObject = uiPrefab;
        gameObject.SetActive(true);
    }

    public void ClearExamineObject() {
        Destroy(currentObject);
        currentObject = null;
        gameObject.SetActive(false);
    }
}
