using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI itemAmount;

    Item itemStocked;

    private int amount;
    public int Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            //itemAmount.enabled = itemStocked != null && itemStocked.ItemBase.maximumStacks > 1 && amount > 1;
            if (itemAmount.enabled)
            {
                itemAmount.text = amount.ToString();
            }
        }
    }

    private void OnValidate()
    {
        if (itemIcon == null)
            itemIcon = GetComponentInChildren<Image>();

        if (itemAmount == null)
            itemAmount = GetComponentInChildren<TextMeshProUGUI>();
    }

    //[SerializeField]
    //GameObject itemEquipedIndicator;

    public void SetItemStocked(Item item)
    {
        this.itemStocked = item;
        DisplaySlot();
    }

    public void DisplaySlot()
    {
        if(itemStocked != null)
        {
            this.itemIcon.sprite = this.itemStocked.ItemBase.icon;
            if(itemStocked.Amount > 1)
            {
                Amount = itemStocked.Amount;
            }
            else
            {
                itemAmount.text = "";
            }
        }
    }

    /*private void Update()
    {
        if (itemStocked.IsEquiped)
            itemEquipedIndicator.SetActive(true);
        else
            itemEquipedIndicator.SetActive(false);
    }*/

    /*public void DisplaySlot(GeneratedItem item)
    {
        itemStocked = item;
        itemIcon.sprite = item.icon;
    }*/

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemStocked.GetType() == typeof(ConsumableItem))
        {   
            GameManager._instance.Player.Consume((ConsumableItem)itemStocked);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager._instance.DisplayToolTipPanel(this.itemStocked);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager._instance.HideToolTipPanel();
    }

    private void OnDestroy()
    {
        UIManager._instance.HideToolTipPanel();
    }
}
