using UnityEngine;
using UnityEngine.InputSystem;
using Interactions;

namespace Inputs
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Interaction))]
    public class InputHandler : MonoBehaviour
    {
        private InputSystem inputSystem;
        private Movement movement;
        private Interaction interaction;

        //public Action PutGet;

        void Awake()
        {
            movement = GetComponent<Movement>();
            interaction = GetComponent<Interaction>();
            inputSystem = new InputSystem();
            // change later
            inputSystem.Cooking.Enable();
            inputSystem.Cooking.PutGet.performed += PutGet_performed;
        }

        void Update()
        {
            Vector2 inputVector = inputSystem.Cooking.Movement.ReadValue<Vector2>();
            movement.Move(inputVector);
        }

        void PutGet_performed(InputAction.CallbackContext context)
        {
            if (interaction.Available) interaction.Perform();
        }
    }
}