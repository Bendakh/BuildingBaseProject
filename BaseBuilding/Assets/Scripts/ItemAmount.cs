using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CostType
{
    WOOD,
    IRON,
    GRASS
}

[Serializable]
public class ItemAmount
{
    public ItemBase item;
    [Range(1,999)]
    public int itemNumber;
}

[Serializable]
public class Cost
{  
    public CostType costType;
    [Range(1,999)]
    public int costValue;
}
