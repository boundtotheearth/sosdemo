using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private CameraInputData cameraInputData = null;
    [SerializeField] private MovementInputData movementInputData = null;
    [SerializeField] private InteractionController interactionControler = null;

    void Start()
    {
        cameraInputData.ResetInput();
        movementInputData.ResetInput();
    }

    void Update()
    {
        GetCameraInput();
        GetMovementInputData();
        GetInteractionInputData();
    }

    void GetInteractionInputData()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactionControler.OnInteractStart();
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            interactionControler.OnInteractEnd();
        }
    }

    void GetCameraInput()
    {
        cameraInputData.InputVectorX = Input.GetAxis("Mouse X");
        cameraInputData.InputVectorY = Input.GetAxis("Mouse Y");

        cameraInputData.ZoomClicked = Input.GetMouseButtonDown(1);
        cameraInputData.ZoomReleased = Input.GetMouseButtonUp(1);
    }

    void GetMovementInputData()
    {
        movementInputData.InputVectorX = Input.GetAxisRaw("Horizontal");
        movementInputData.InputVectorY = Input.GetAxisRaw("Vertical");

        movementInputData.RunClicked = Input.GetKeyDown(KeyCode.LeftShift);
        movementInputData.RunReleased = Input.GetKeyUp(KeyCode.LeftShift);

        if(movementInputData.RunClicked)
            movementInputData.IsRunning = true;

        if(movementInputData.RunReleased)
            movementInputData.IsRunning = false;

        movementInputData.JumpClicked = Input.GetKeyDown(KeyCode.Space);
        movementInputData.CrouchClicked = Input.GetKeyDown(KeyCode.LeftControl);
    }
}