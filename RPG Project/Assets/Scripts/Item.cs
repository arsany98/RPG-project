﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/item")]
public class Item : ScriptableObject {

    public string itemName = "New item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {

        Debug.Log("Using "+ name);
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}