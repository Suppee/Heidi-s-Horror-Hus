using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    //Camera control variables
    public float cameraSensitivity = 25f;
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;

    Vector2 lookValue;
    public Transform playerCamera;

    //Movement variables
    public float moveSpeed;
    Vector2 moveValue;
    public bool isGrounded;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Character movement
        Vector3 move = (transform.right * moveValue.x + transform.forward * moveValue.y) * moveSpeed;
        controller.Move(move * Time.deltaTime);

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
        MouseLook();
    }

    private void FixedUpdate()
    {
        
    }

    private void MouseLook()
    {
        float xRotCamera = 0;
        float yRotCamera;
        float mouseX = lookValue.x * sensitivityX;
        float mouseY = lookValue.y * sensitivityY;

        // Create local variable and set it to cameras rotation
        Vector3 rot = playerCamera.transform.localRotation.eulerAngles;

        // Adds the mouse x value as rotation on the camera (left/right rotation around the cameras Y axis)
        yRotCamera = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotCamera -= mouseY;
        //Clamps the up and down rotation between -90 and 90 degrees to avoid 
        xRotCamera = Mathf.Clamp(xRotCamera, -90f, 90f);

        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotCamera;
        playerCamera.eulerAngles = targetRotation;

        //Rotate camera up and down  
       //playerCamera.transform.localRotation = Quaternion.Euler(xRotCamera, yRotCamera, 0);

        // Rotate whole character when moving mouse left/right
        //transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        //transform.localRotation = Quaternion.Euler(0, yRotCamera, 0);
    }

    // Input value from mouse 
    public void Look(InputAction.CallbackContext context)
    {
        lookValue = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
    }

    // Input values from WASD
    public void Move(InputAction.CallbackContext context)
    {
        moveValue = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
        //Debug.Log(moveValue);
    }

    // Input value from Interact
    public void Interact(InputAction.CallbackContext context)
    {
        RaycastHit hit;
            if(Physics.Raycast(transform.position, playerCamera.forward, out hit, 10))
            {

            }
    }
}
