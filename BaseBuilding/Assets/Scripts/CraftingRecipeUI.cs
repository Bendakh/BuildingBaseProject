using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeUI : MonoBehaviour
{
    [SerializeField]
    CraftingWindowItemSlot[] componentSlots;
    [SerializeField]
    CraftingWindowItemSlot resultSlot;

    [SerializeField]
    CraftRecipe craftRecipe;

    [SerializeField]
    Button craftButton;

    // Start is called before the first frame update
    void Start()
    {
        InitializeCraftingRecipeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCraftRecipe(CraftRecipe craftRecipe)
    {
        this.craftRecipe = craftRecipe;

        if(this.craftRecipe != null)
        {
            InitializeCraftingRecipeUI();
        }
    }


    //change this so we instantiate slots 
    public void InitializeCraftingRecipeUI()
    {
        int i = 0;

        foreach (Cost cost in craftRecipe.primaryMaterials)
        {
            componentSlots[i].InitializeResource(cost.costType, cost.costValue);
            i++;
        }

        foreach (ItemAmount itemAmount in craftRecipe.itemMaterials)
        {
            componentSlots[i].InitializeItem(itemAmount.item, itemAmount.itemNumber);
            i++;
        }

        resultSlot.InitializeItem(craftRecipe.results[0].item, craftRecipe.results[0].itemNumber);

        craftButton.onClick.AddListener(() => this.craftRecipe.Craft(GameManager._instance.Player.GetInventory()));
    }
}
