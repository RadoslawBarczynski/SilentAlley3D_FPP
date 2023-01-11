using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : Interactable
{
    public Item item;

    protected override void Interact()
    {
        Debug.Log("Interacted with " + item.name);

        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);

    }
}
