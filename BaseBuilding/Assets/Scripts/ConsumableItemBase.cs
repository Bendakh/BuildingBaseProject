using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConsumableValue
{
    [SerializeField] EnumTypes.ConsumablesValuesTypes consumableTarget;
    [SerializeField] int value;

    public EnumTypes.ConsumablesValuesTypes ConsumableTarget { get => consumableTarget; }
    public int Value { get => value; }
}

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Stuff/Consumable Item")]
public class ConsumableItemBase : ItemBase
{
    public List<ConsumableValue> consumableValues;

    public override Item GetCopy()
    {
        ConsumableItem item = new ConsumableItem(this);
        return item;
    }
}
