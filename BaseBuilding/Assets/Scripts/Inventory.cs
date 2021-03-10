using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    public List<Item> inventory = new List<Item>();

    private int inventoryCapacity = 999;

    public int InventoryCapacity { get => inventoryCapacity; }
    //when we add an item we set this variable to false and when we update we set it to true, this or we destroy all children in the inventory when we close it 
    private bool isUpdated = true;

    [SerializeField]
    GameObject slotsContainer;

    [SerializeField]
    GameObject slotPrefab;

    bool isInventoryDisplayed = false;

    private void Start()
    {
        isInventoryDisplayed = false;
        isUpdated = false;

        UpdateInventory();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isInventoryDisplayed = !isInventoryDisplayed;

            if (isInventoryDisplayed)
                DisplayInventory();
            else
                slotsContainer.SetActive(false);
            
        }


        if(!isUpdated)
        {
            UpdateInventory();
        }
    }

    private void ResetInventory()
    {
        //Reset the inventory
        ItemSlot[] itemSlotList = slotsContainer.GetComponentsInChildren<ItemSlot>();
        foreach (ItemSlot itemSlot in itemSlotList)
        {
            Destroy(itemSlot.gameObject);
        }

    }

    public void DisplayInventory()
    {
        //ResetInventory();

        slotsContainer.SetActive(true);
        if (!isUpdated)
            UpdateInventory();
    }
    public void HideInventory()
    {
        slotsContainer.SetActive(false);
    }


    private void UpdateInventory()
    {
        ResetInventory();
        foreach (Item item in inventory)
        {
            //int amount = ItemCountById(item.ItemBase.id);

            if(item.ItemBase.maximumStacks > 1)
            {
                ItemSlot stackableItemSlot = Instantiate(slotPrefab, slotsContainer.transform).GetComponent<ItemSlot>();
                stackableItemSlot.Amount = ItemCountById(item.ItemBase.id);
                stackableItemSlot.SetItemStocked(item);
            }
            else
            {
                ItemSlot itemSlot = Instantiate(slotPrefab, slotsContainer.transform).GetComponent<ItemSlot>();
                itemSlot.SetItemStocked(item);
            }          
        }

        isUpdated = true;
    }

    public void SetNonUpdated()
    {
        this.isUpdated = false;
    }

    public bool ContainsItem(Item item)
    {
        if (inventory.Contains(item))
        {
            return true;
        }
        else
            return false;
    }


    /*public bool RemoveItem(Item item)
    {
        if (ContainsItem(item))
        {           
                isUpdated = false;
                return inventory.Remove(item);          
        }
        else
            return false;
    }*/

    public bool RemoveItem(ItemBase itemBase)
    {
        Item item = inventory.Find(i => i.ItemBase.id == itemBase.id);
        if (item != null)
        {
            if(item.Amount > 1)
            {
                item.Amount--;
                isUpdated = false;
                return true;
            }
            else
            {
                isUpdated = false;
                return inventory.Remove(item);
            }
        }
        else
            return false;
    }

    public bool AddItem(Item item)
    {
        if (inventory.Count < inventoryCapacity)
        {
            if(ItemCountById(item.ItemBase.id) > 0 && item.ItemBase.maximumStacks > 1)
            {   
                Item itemToIncrement = inventory.Find(i => i.ItemBase.id == item.ItemBase.id);
                itemToIncrement.Amount++;
                isUpdated = false;
                return true;
            }
            else
            {
                inventory.Add(item);
                item.Amount = 1;
                isUpdated = false;
                return true;
            }      
        }
        else
        {
            return false;
        }      
    }

    public bool IsFull()
    {
        return inventory.Count >= inventoryCapacity;
    }

    public int ItemCount(Item item)
    {
        return inventory.FindAll(i => i == item).Count;
    }

    public int ItemCountById(int id)
    {
        return inventory.FindAll(i => i.ItemBase.id == id).Count;
    }
}
