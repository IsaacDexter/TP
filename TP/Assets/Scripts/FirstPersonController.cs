using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//credit to https://www.youtube.com/@AllThingsGameDev

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField, Range(0.0f, 20.0f)] private float walkSpeed = 6f;
    [SerializeField, Range(0.0f, 20.0f)] private float jumpPower = 5f;
    [SerializeField, Range(0.0f, 20.0f)] private float gravity = 10f;

    [SerializeField, Range(0.0f, 10.0f)] private float lookSpeed = 2f;
    [SerializeField, Range(0.0f, 90.0f)] private float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [SerializeField] private bool canMove = true;
    private Vector2 curSpeed = Vector2.zero;

    CharacterController characterController;

    // Start is called before the first frame update

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        curSpeed.x = canMove ? (walkSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeed.y = canMove ? (walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeed.x) + (right * curSpeed.y);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if(!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }


        characterController.Move(moveDirection * Time.deltaTime);

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
