using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipable Item", menuName = "Stuff/Equipable Item")]
public class EquipableItemBase : ItemBase
{
    public List<CharacterStatModifier> modifiersList;

    public override Item GetCopy()
    {
        EquipableItem item = new EquipableItem(this);
        return item;
    }
}
