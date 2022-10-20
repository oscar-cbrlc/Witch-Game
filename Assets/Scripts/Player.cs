using UnityEngine;
using Interactions;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Interaction))]
public class Player : MonoBehaviour
{
    public Movement movement;

    public Interaction interaction;

    public GameObject HeldItem {get; private set;}

    public Transform item;

    public void HoldItem(GameObject newItem)
    {
        HeldItem = newItem;
        HeldItem.transform.position = item.transform.position;
        HeldItem.transform.parent = item.transform;
    }

    public GameObject DropItem()
    {
        GameObject p_item = HeldItem;
        HeldItem = null;
        return p_item;
    }
    
}