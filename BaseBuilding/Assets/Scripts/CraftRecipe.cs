using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CraftRecipe : ScriptableObject
{
    public List<Cost> primaryMaterials;
    public List<ItemAmount> itemMaterials;
    public List<ItemAmount> results;

    public bool CanCraft(IItemContainer inv)
    {
        foreach(Cost primMat in primaryMaterials)
        {
            if(!GameManager._instance.Player.IsThereEnoughResource(primMat.costType,primMat.costValue))
            {
                return false;
            }
        }

        foreach(ItemAmount itemAmount in itemMaterials)
        {    
            if(inv.ItemCountById(itemAmount.item.id) < itemAmount.itemNumber)
            {
                return false;
            }
        }

        return true;
    }

    public void Craft(IItemContainer inv)
    {
        if(CanCraft(inv))
        {
            foreach (Cost cost in primaryMaterials)
            {
                GameManager._instance.Player.DepleteFromResource(cost.costType, cost.costValue);
            }

            foreach(ItemAmount itemAmount in itemMaterials)
            {
                for(int i = 0; i < itemAmount.itemNumber; i++)
                {
                    inv.RemoveItem(itemAmount.item);
                }
            }

            foreach(ItemAmount itemAmount in results)
            {
                for(int i = 0; i < itemAmount.itemNumber; i++)
                {            
                    inv.AddItem(itemAmount.item.GetCopy());
                }
            }           
        }
    }
}
