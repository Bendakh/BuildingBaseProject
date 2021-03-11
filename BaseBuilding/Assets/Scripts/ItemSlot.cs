using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/
{

    private float startPosX;
    private float startPosY;

    private bool isMoving = false;

    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI itemAmount;

    Item itemStocked;

    public Item ItemStocked { get => itemStocked; }

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

        if (itemStocked.GetType() == typeof(EquipableItem))
        {
            Debug.Log("Equip");
            GameManager._instance.Player.EquipUnequipItem((EquipableItem)itemStocked);
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

    private void Update()
    {
        
    }


    /*public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End dragging");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin dragging");
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - transform.localPosition.x;
        startPosY = mousePos.y - transform.localPosition.y;

    }*/
}
