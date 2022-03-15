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
        //local variables
        float mouseX = lookValue.x * sensitivityX;
        float mouseY = lookValue.y * sensitivityY;

        // Rotate whole character when moving mouse left/right
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        //Rotate camera up and down  
        playerCamera.Rotate(Vector3.right, -mouseY * Time.deltaTime);

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
}
