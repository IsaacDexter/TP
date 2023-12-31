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
    [SerializeField, Range(0.0f, 20.0f)] private float runSpeed = 12f;
    [SerializeField, Range(0.0f, 20.0f)] private float runCost = 12f;
    [SerializeField, Range(0.0f, 20.0f)] private float jumpPower = 7f;
    [SerializeField, Range(0.0f, 20.0f)] private float gravity = 10f;

    [SerializeField, Range(0.0f, 10.0f)] private float lookSpeed = 2f;
    [SerializeField, Range(0.0f, 90.0f)] private float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [SerializeField] private bool canMove = true;
    private bool isRunning = false;
    private Vector2 curSpeed = Vector2.zero;

    CharacterController characterController;

    // Start is called before the first frame update

    public bool IsRunning()
    {
        //If the player is running and moving
        return (isRunning && (curSpeed.sqrMagnitude > 0));
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement handler
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Left shift to run
        isRunning = Input.GetKey(KeyCode.LeftShift);
        curSpeed.x = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        curSpeed.y = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeed.x) + (right * curSpeed.y);

        #endregion

        #region Jump handler
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

        #endregion

        #region Rotation handler

        characterController.Move(moveDirection * Time.deltaTime);

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}
