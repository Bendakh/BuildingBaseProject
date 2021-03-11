using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class EquipableItem : Item
{
    private List<CharacterStatModifier> modifiersList;

    public List<CharacterStatModifier> ModifiersList { get => modifiersList; }

    private bool isEquiped = false;

    public bool IsEquiped { get => isEquiped; }

    

    public EquipableItem(EquipableItemBase itemBase) : base(itemBase)
    {
        this.itemBase = itemBase;
        this.modifiersList = itemBase.modifiersList;
    }

    public override void Use()
    {
        base.Use();
        //Equip the item
    }

    public void SetEquiped(bool equip)
    {
        this.isEquiped = equip;
    }
}
