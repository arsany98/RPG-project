using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void interact()
    {
        base.interact();

        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Picking up" + item.itemName);
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
