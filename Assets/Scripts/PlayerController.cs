using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    //Camera control variables
    public float xRotation;
    [SerializeField] [Range(2.5f, 25f)] float sensitivityX = 8f;
    [SerializeField] [Range(2.5f, 25f)] float sensitivityY = 0.5f;

    Vector2 lookValue;
    public Transform playerCamera;

    //Movement variables
    public float moveSpeed;
    Vector2 moveValue;
    public bool isGrounded;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -30f;
    Vector3 verticalVelocity = Vector3.zero;

    //Flashlight variables
    [SerializeField] GameObject FlashlightLight;
    bool FlashlightActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FlashlightLight.gameObject.SetActive(false);
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

    private void MouseLook()
    {
        //local variables
        float mouseX = lookValue.x * sensitivityX * Time.fixedDeltaTime;
        float mouseY = lookValue.y * sensitivityY * Time.fixedDeltaTime;

        //Find current look rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        float desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.localRotation = Quaternion.Euler(0, desiredX, 0);
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
    }

    // Input value from Interact
    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            RaycastHit hit;
            Debug.DrawRay(playerCamera.position, playerCamera.forward * 3, Color.red, 10);
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 3))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    print("Interacting with " + hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }
    }

    // Input value from flashlight
    public void Flashlight(InputAction.CallbackContext context)
    {         

        if (context.performed && FlashlightActive)
        {
            FlashlightActive = false;
        }
        else if (context.performed)
        {
            FlashlightActive = true;
        }

        if (FlashlightActive)
        {
            FlashlightLight.gameObject.SetActive(true);
        }
        else
        {
            FlashlightLight.gameObject.SetActive(false);
        }
    }
}
