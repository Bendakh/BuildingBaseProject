using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item 
{
    protected ItemBase itemBase;
    public ItemBase ItemBase { get => itemBase; }


    public Item(ItemBase itemBase)
    {
        this.itemBase = itemBase;
    }

    public virtual void Use()
    {
        Debug.Log("Using!");
    }
}
