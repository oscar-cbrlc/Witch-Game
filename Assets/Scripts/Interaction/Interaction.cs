using UnityEngine;
using Plating;

namespace Interactions
{  
    [RequireComponent(typeof(Player))]
    public class Interaction : MonoBehaviour
    {
        private Player player;
        public BoxCollider interactionZone;
        [SerializeField]private I_Interactuable interactuable;
        
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
        
        public void PutGet()
        {
            Table table = interactuable as Table;
            if (!table.occupied)
                table.Put(player.DropItem());
            else
                player.HoldItem(table.Get());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Interactuable")
            {
                available = true;
                interactuable = other.GetComponentInChildren<I_Interactuable>();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Interactuable")
            {
                available = false;
                interactuable = null;
            }
        }
    }
}