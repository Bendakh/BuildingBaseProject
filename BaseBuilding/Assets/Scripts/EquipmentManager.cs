using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private List<EquipableItem> equipments = new List<EquipableItem>();

    public List<EquipableItem> Equipments { get => equipments; }

    public void Equip(EquipableItem equipableItem)
    {
        if(!equipableItem.IsEquiped)
        {
            equipments.Add(equipableItem);
            GameManager._instance.Player.AddItemModifiers(equipableItem);
            equipableItem.SetEquiped(true);
            //Equiping sound
        }   
    }

    public void Unequip(EquipableItem equipableItem)
    {
        if(equipableItem.IsEquiped)
        {
            GameManager._instance.Player.RemoveItemModifiers(equipableItem);
            equipments.Remove(equipableItem);
            equipableItem.SetEquiped(false);
        }
    }
}
