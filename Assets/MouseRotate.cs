using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float sensitivity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInput = new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
        transform.Rotate(mouseInput * sensitivity, Space.World);
    }
}
