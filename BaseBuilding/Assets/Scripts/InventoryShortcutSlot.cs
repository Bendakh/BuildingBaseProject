using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryShortcutSlot : MonoBehaviour
{
    [SerializeField] KeyCode keyCodeShortcut;

    Item stockedItem;

    [SerializeField] InventoryShortcuts inventoryShortcutContainer;

    [SerializeField] Image imageIcon;

    public Item StockedItem { get => stockedItem; }

    bool isUsed = false;

    Button iconShortcutButton;

    public void SetStockedItem(Item itemToStock)
    {
        if (!isUsed)
        {
            this.stockedItem = itemToStock;
            //iconShortcutButton.onClick.AddListener(() => SetShortcutToItem());
            imageIcon.sprite = itemToStock.ItemBase.icon;
            isUsed = true;
        }
    }

    public void ResetInventoryShortcutSlot()
    {
        this.stockedItem = null;
        iconShortcutButton.onClick.RemoveAllListeners();
        isUsed = false;
    }

    public bool ShortcutSlotHovered()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(this.transform as RectTransform, Input.mousePosition))
        {
            Debug.Log(this.gameObject.name + " hovered");
            return true;
        }
        else
            return false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCodeShortcut))
        {
            stockedItem.Use();
        }
    }


    /*private void SetShortcutToItem()
    {
        inventoryShortcutContainer.SetItemShortcutted(this.stockedItem);
    }*/


}
