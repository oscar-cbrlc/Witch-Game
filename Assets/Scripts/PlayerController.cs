using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMove, zMove;
    private Vector3 playerInput;

    private float rotation;
    [SerializeField] private float rotationSpeed;

    private CharacterController characterController;
    

    [SerializeField] private float movementSpeed;
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(xMove, 0, zMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        Debug.Log("Z: " + zMove);
        Debug.Log("X: " + xMove);
    }

    void FixedUpdate()
    {
        characterController.Move(playerInput * movementSpeed * Time.deltaTime);
        Rotate();
    }

    void Rotate()
    {
        if(xMove != 0)
        {
            if (xMove > 0)
                transform.rotation = Quaternion.Euler(new Vector3()); // right
            else
                transform.rotation = Quaternion.Euler(new Vector3(0,180,0)); // left
        }
        if(zMove != 0)
        {
            if (zMove > 0)
                transform.rotation = Quaternion.Euler(new Vector3(0,270,0)); // up
            else
                transform.rotation = Quaternion.Euler(new Vector3(0,90,0)); // down
        }
    }
}
