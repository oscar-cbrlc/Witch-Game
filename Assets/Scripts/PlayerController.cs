using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMove, zMove;
    private Vector3 playerInput;
    
    public float movementSpeed;

    private float rotation;
    public float rotationSpeed;

    private CharacterController characterController;
      
    void Start()
    {
        characterController = GetComponent<CharacterController>();    
    }

    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(xMove, 0, zMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        Rotate();
    }

    void FixedUpdate()
    {
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
