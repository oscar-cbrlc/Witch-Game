using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float xMove, zMove;
    private Vector3 playerInput;

    private CharacterController characterController;
    

    [SerializeField] private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
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
    }

    void FixedUpdate()
    {
        characterController.Move(playerInput * speed * Time.deltaTime);
    }
}
