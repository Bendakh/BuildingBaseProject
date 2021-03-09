using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ConsumableItem : Item
{

    private List<ConsumableValue> consumableValues;

    public List<ConsumableValue> ConsumableValues { get => consumableValues; }

    public ConsumableItem(ConsumableItemBase itemBase) : base(itemBase)
    {
        this.itemBase = itemBase;
        consumableValues = itemBase.consumableValues;
    }

    public override void Use()
    {
        base.Use();
        Debug.Log("yey");
        GameManager._instance.Player.Consume(this);
    }


}
