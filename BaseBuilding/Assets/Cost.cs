using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CostType
{
    WOOD,
    IRON,
    GRASS
}

[SerializeField]
public class Cost 
{
    public CostType costType;
    public int costValue;

}
