using UnityEngine;
using Plating;

namespace Interactions
{  
    [RequireComponent(typeof(Player))]
    public class Interaction : MonoBehaviour
    {
        private Player player;
        public BoxCollider interactionZone;
        [SerializeField]private I_Interactable interactable;
        
        [SerializeField]
        private bool available;
        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        private void Awake()
        {
            player = GetComponent<Player>();
        }
        

        public void Perform()
        {
            interactable.PerformInteraction(player);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Interactable")
            {
                available = true;
                interactable = other.GetComponentInChildren<I_Interactable>();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Interactable")
            {
                available = false;
                interactable = null;
            }
        }
    }
}