using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    Inventory inventory;
    public GameObject inventoryHUD;
    InventorySlot[] inventoryHUDSlots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateHUD;
        inventoryHUDSlots = inventoryHUD.transform.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            inventoryHUD.SetActive(!inventoryHUD.activeSelf);
        }
    }

    void UpdateHUD()
    {
        for (int i = 0; i < inventoryHUDSlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                inventoryHUDSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                inventoryHUDSlots[i].ClearSlot();
            }
        }
    }
}
