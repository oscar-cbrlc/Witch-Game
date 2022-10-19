using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private float xMove, zMove;
    private Vector3 playerInput;
    
    public float movementSpeed;

    private float rotation;
    public float rotationSpeed;

    private CharacterController characterController;

    private bool mobile = false;
      
    void Start()
    {
        # if UNITY_ANDROID
            mobile = true;
        # endif
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(mobile)
        {
            xMove = joystick.Horizontal * 10;
            zMove = joystick.Vertical * 10;
        }
        else
        {
            xMove = Input.GetAxis("Horizontal");
            zMove = Input.GetAxis("Vertical");
        }
        playerInput = new Vector3(xMove, 0, zMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        Rotate();
    }

    void FixedUpdate()
    {
        Debug.Log(playerInput);
        characterController.Move(playerInput * movementSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        if(playerInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
