using UnityEngine;
using Interactions;

namespace Plating
{
    public class Table : MonoBehaviour, I_Interactuable
    {
        [SerializeField]
        private GameObject item;
        public GameObject Item
        {
            get {return item;}
            set {item = value;}
        }

        public bool occupied;
        
        
        [SerializeField]
        private Transform itemPosition;
        
        private void Awake()
        {
            occupied = Item != null;
            if (occupied)
            {
                Item.transform.position = itemPosition.position;
                Item.transform.parent = itemPosition;
            }
        }

        public void Put(GameObject item)
        {
            if (item == null) return;
            Item = item;
            Item.transform.position = itemPosition.position;
            Item.transform.parent = itemPosition;
            occupied = true;
        }

        public GameObject Get()
        {
            GameObject pItem = Item;
            Item = null;
            occupied = false;
            return pItem;
        }

        public void PerformInteraction()
        {
            // something
        }
    }
}