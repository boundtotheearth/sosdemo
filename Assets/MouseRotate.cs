using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float sensitivity = 1f;
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sensitivity;

            transform.RotateAround(transform.position, myCamera.transform.right, mouseInput.y);
            transform.RotateAround(transform.position, myCamera.transform.up, -mouseInput.x);
        }
    }
}
