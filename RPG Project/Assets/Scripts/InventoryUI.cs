using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public GameObject itemParent;

    Inventory inventory;

    InventorySlot[] slots;

    public GameObject inventoryUI;

    void Start () {
        inventory = Inventory.instance;
        inventory.Callback += UpdateUI;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (inventoryUI.activeSelf)
                inventoryUI.SetActive(false);
            else
                inventoryUI.SetActive(true);
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.Items.Count)
            {
                slots[i].AddItem(inventory.Items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
