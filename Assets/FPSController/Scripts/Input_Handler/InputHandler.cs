using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private CameraInputData cameraInputData = null;
    [SerializeField] private MovementInputData movementInputData = null;
    [SerializeField] private InteractionController interactionControler = null;
    [SerializeField] private CluesUI cluesUI = null;

    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canLook = true;
    [SerializeField] private bool canInteract = true;
    [SerializeField] private bool canMenu = true;

    void Start()
    {
        ResetInput();
    }

    void Update()
    {
        if(canLook) {
            GetCameraInput();
        }
        if(canMove) {
            GetMovementInputData();
        }
        if(canInteract) {
            GetInteractionInputData();
        }
        if(canMenu) {
            GetMenuInput();
        }
    }

    void GetInteractionInputData()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactionControler.ToggleInteract();
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

    void GetMenuInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            cluesUI.ToggleMenu();
        }
    }

    public void ResetInput() {
        cameraInputData.ResetInput();
        movementInputData.ResetInput();
    }

    public void DisableMovementInput() {
        ResetInput();
        canMove = false;
    }

    public void DisableCameraInput() {
        ResetInput();
        canLook = false;
    }

    public void DisableInteractionInput() {
        ResetInput();
        canInteract = false;
    }

    public void DisableMenuInput() {
        ResetInput();
        canMenu = false;
    }

    public void EnableMovementInput() {
        ResetInput();
        canMove = true;
    }

    public void EnableCameraInput() {
        ResetInput();
        canLook = true;
    }

    public void EnableInteractionInput() {
        ResetInput();
        canInteract = true;
    }

    public void EnableMenuInput() {
        ResetInput();
        canMenu = true;
    }
}