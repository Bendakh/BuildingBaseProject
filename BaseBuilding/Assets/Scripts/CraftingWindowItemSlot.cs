using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingWindowItemSlot : MonoBehaviour
{
    [SerializeField]
    Image itemIcon;

    [SerializeField]
    TextMeshProUGUI itemQuantity;

    //Temporary
    [SerializeField]
    Sprite[] spritesArray;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeItem(ItemBase item, int value)
    {
        itemIcon.sprite = item.icon;
        itemQuantity.text = value.ToString();
    }

    public void InitializeResource(CostType costType, int value)
    {
        switch(costType)
        {
            case CostType.WOOD:
                itemIcon.sprite = spritesArray[1];
                break;

            case CostType.IRON:
                itemIcon.sprite = spritesArray[0];
                break;

            case CostType.GRASS:
                itemIcon.sprite = spritesArray[2];
                break;
        }

        itemQuantity.text = value.ToString();
    }
}
