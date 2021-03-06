﻿using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            changeInteractionStatus();
            Destroy(gameObject);
        } else
        {
            OnDefocused();
        }
    }
}
