using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    Inventory inventory;
    public Transform primaryItemsParent;
    public Transform secondaryItemsParent;
    public GameObject inventoryUI;
    InventorySlot[] primarySlots;
    InventorySlot[] secondarySlots;
    bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateMenu;
        primarySlots = primaryItemsParent.GetComponentsInChildren<InventorySlot>();
        secondarySlots = secondaryItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void UpdateMenu()
    {
        Debug.Log("UPDATING INVENTORY MENU");
        for (int i = 0; i < primarySlots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                primarySlots[i].AddItem(inventory.items[i]);
            } else
            {
                primarySlots[i].ClearSlot();
            }
        }

        for (int i = 2; i < secondarySlots.Length + 2; i++)
        {
            if (i < inventory.items.Count)
            {
                secondarySlots[i - 2].AddItem(inventory.items[i]);
            } else
            {
                secondarySlots[i - 2].ClearSlot();
            }
        }
    }

    void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
