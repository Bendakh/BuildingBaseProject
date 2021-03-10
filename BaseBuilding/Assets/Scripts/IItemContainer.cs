using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer 
{
    bool ContainsItem(Item item);
    //bool RemoveItem(Item item);
    bool RemoveItem(ItemBase itemBase);
    bool AddItem(Item item);
    bool IsFull();

    int ItemCount(Item item);

    int ItemCountById(int i);
}
