using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler*/
{
    [SerializeField]
    Image itemIcon;

    Item itemStocked;

    //[SerializeField]
    //GameObject itemInformationPanelPrefab;

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

    /*public void OnPointerClick(PointerEventData eventData)
    {
        UIManager._instance.DisplayItemPanel(itemStocked);
    }*/

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Display");
        iid = Instantiate(itemInformationPanelPrefab, this.gameObject.transform.parent.parent).GetComponent<ItemInformationDisplay>();
        iid.DisplayItem(itemStocked);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hide");
        if (iid != null)
        {
            Destroy(iid.gameObject);
        }
    }*/
}
