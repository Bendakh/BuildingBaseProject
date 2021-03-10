using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShortcuts : MonoBehaviour
{
    [SerializeField] List<InventoryShortcutSlot> inventoryShortcutSlots;

    Item itemShortcutted;

    public Item ItemShortcutted { get => itemShortcutted; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemShortcutted != null)
            UseShortcutItem();
    }

    public void SetItemShortcutted(Item itemToShortcut)
    {
        this.itemShortcutted = itemToShortcut;
    }

    public void UseShortcutItem()
    {
        itemShortcutted.Use();
    }
}
