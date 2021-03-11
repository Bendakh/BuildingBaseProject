using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Interactable
{
    [SerializeField] List<Cost> resourcesCost;
    [SerializeField] List<ItemAmount> itemMaterials;

    [SerializeField] int buildMaxValue;
    int buildValue = 0;

    [SerializeField] GameObject finalFormPrefab;

    [SerializeField] int energyCost;

    public bool CanBuild(IItemContainer inv)
    {
        foreach(Cost cost in resourcesCost)
        {
            if(!GameManager._instance.Player.IsThereEnoughResource(cost.costType, cost.costValue))
            {
                return false;
            }
        }

        foreach (ItemAmount itemAmount in itemMaterials)
        {
            if(inv.ItemCountById(itemAmount.item.id) < itemAmount.itemNumber)
            {
                return false;
            }
        }

        return true;
    }

    public void Build(IItemContainer inv)
    {
        foreach (Cost cost in resourcesCost)
        {
            GameManager._instance.Player.DepleteFromResource(cost.costType, cost.costValue);
        }

        foreach (ItemAmount itemAmount in itemMaterials)
        {
            for (int i = 0; i < itemAmount.itemNumber; i++)
            {
                inv.RemoveItem(itemAmount.item);
            }
        }

        buildValue = 0;
    }

    public override void Interact()
    {
        if (isInteractable && GameManager._instance.Player.CurrentEnergy >= this.energyCost)
        {
            base.Interact();
            GameManager._instance.DepletePlayerEnergy(energyCost);
            buildValue += 5;
            if (IsBuildingComplete())
            {
                FinaliseBuilding();
            }
        }
    }

    private bool IsBuildingComplete()
    {
        return buildValue >= buildMaxValue;
    }

    private void FinaliseBuilding()
    {
        Instantiate(finalFormPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
