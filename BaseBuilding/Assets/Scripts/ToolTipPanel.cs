using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTipPanel : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemText;

    public void DisplayToolTipPanel(Item item)
    {
        itemImage.sprite = item.ItemBase.icon;
        itemText.text = item.ItemBase.itemName;
    }

    public void ResetToolTipPanel()
    {
        itemImage.sprite = null;
        itemText.text = "";
    }
}
