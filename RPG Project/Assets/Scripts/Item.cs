using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/item")]
public class Item : ScriptableObject {

    public string itemName = "New item";
    public Sprite icon = null;
    public bool isEquipped = false;
}