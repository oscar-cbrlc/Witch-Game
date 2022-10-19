using UnityEngine;

namespace Inputs
{
    [RequireComponent(typeof(Movement))]
    public class InputHandler : MonoBehaviour
    {
        private InputSystem inputSystem;
        private Movement movement;

        void Awake()
        {
            movement = GetComponent<Movement>();
            inputSystem = new InputSystem();
            // change later
            inputSystem.Cooking.Enable();
        }

        void Update()
        {
            Vector2 inputVector = inputSystem.Cooking.Movement.ReadValue<Vector2>();
            movement.Move(inputVector);
        }
    }
}