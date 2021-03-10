using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryShortcutSlot : MonoBehaviour
{
    Item stockedItem;

    [SerializeField] InventoryShortcuts inventoryShortcutContainer;

    public Item StockedItem { get => stockedItem; }

    bool isUsed;

    Button iconShortcutButton;

    public void SetStockedItem(Item itemToStock)
    {
        if (!isUsed)
        {
            this.stockedItem = itemToStock;
            iconShortcutButton.onClick.AddListener(() => SetShortcutToItem());
            isUsed = true;
        }
    }

    public void ResetInventoryShortcutSlot()
    {
        this.stockedItem = null;
        iconShortcutButton.onClick.RemoveAllListeners();
        isUsed = false;
    }

    private void SetShortcutToItem()
    {
        inventoryShortcutContainer.SetItemShortcutted(this.stockedItem);
    }
}
