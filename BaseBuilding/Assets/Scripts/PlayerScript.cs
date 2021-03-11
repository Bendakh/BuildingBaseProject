using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isTired;
    //change this to stats
    public CharacterStat health;
    public CharacterStat energy;

    private int currentHealth;
    private int currentEnergy;


    private int ironStock;
    private int woodStock;
    private int grassStock;

    public int CurrentHealth { get => currentHealth; }
    public int CurrentEnergy { get => currentEnergy; }

    public int IronStock { get => ironStock; }
    public int WoodStock { get => woodStock; }

    public int GrassStock { get => grassStock; }


    public void AddIronStock(int value)
    {
        this.ironStock += value;
    }

    public void AddWoodStock(int value)
    {
        this.woodStock += value;
    }

    public void AddGrassStock(int value)
    {
        this.grassStock += value;
    }

    public void DepleteIronStock(int value)
    {
        this.ironStock -= value;
    }

    public void DepleteWoodStock(int value)
    {
        this.woodStock -= value;
    }

    public void DepleteGrassStock(int value)
    {
        this.grassStock -= value;
    }

    public void DepleteFromResource(CostType resourceType, int value)
    {
        switch(resourceType)
        {
            case CostType.WOOD:
                DepleteWoodStock(value);
                break;

            case CostType.IRON:
                DepleteIronStock(value);
                break;

            case CostType.GRASS:
                DepleteGrassStock(value);
                break;
        }
    }

    public Inventory GetInventory()
    {
        return GetComponent<Inventory>();
    }

    public EquipmentManager GetEquipmentManager()
    {
        return GetComponent<EquipmentManager>();
    }

    public bool IsThereEnoughResource(CostType resourceType, int resourceValue)
    {
        bool isEnough = true;
        switch(resourceType)
        {
            case CostType.WOOD:
                if (woodStock < resourceValue)
                    isEnough = false;
                break;

            case CostType.IRON:
                if (ironStock < resourceValue)
                    isEnough = false;
                break;

            case CostType.GRASS:
                if (grassStock < resourceValue)
                    isEnough = false;
                break;
        }

        return isEnough;
    }

    public void Consume(ConsumableItem consumableItem)
    {
        
        foreach(ConsumableValue cv in consumableItem.ConsumableValues)
        {
            switch(cv.ConsumableTarget)
            {
                case EnumTypes.ConsumablesValuesTypes.HEALTH:
                    currentHealth += cv.Value;
                    break;
                case EnumTypes.ConsumablesValuesTypes.ENERGY:
                    currentEnergy += cv.Value;
                    break;
            }
        }

        GetInventory().RemoveItem(consumableItem.ItemBase);
        //check garbage collector to destroy the item
    }

    public void EquipUnequipItem(EquipableItem equipableItem)
    {
        if(equipableItem.IsEquiped)
        {
            GetComponent<EquipmentManager>().Unequip(equipableItem);
        }
        else
        {
            GetComponent<EquipmentManager>().Equip(equipableItem);
        }
    }

    public void DepleteEnergy(int energy)
    {
        this.currentEnergy -= energy;
    }

    public void AddItemModifiers(EquipableItem equipableItem)
    {
        foreach (CharacterStatModifier sm in equipableItem.ModifiersList)
        {
            switch (sm.targetStat)
            {
                case TargetStat.HEALTH:
                    sm.source = equipableItem;
                    health.AddModifier(sm);
                    health.SetDirty();
                    break;
                case TargetStat.ENERGY:
                    sm.source = equipableItem;
                    energy.AddModifier(sm);
                    energy.SetDirty();
                    break;
            }
        }
    }

    public void RemoveItemModifiers(EquipableItem equipableItem)
    {
        if (health.RemoveAllModifiersFromSource(equipableItem))
            Debug.Log("Health cleared");
        if (energy.RemoveAllModifiersFromSource(equipableItem))
            Debug.Log("Energy cleared");
    }

    // Start is called before the first frame update
    void Start()
    {
        health = new CharacterStat(100f);
        energy = new CharacterStat(100f);

        currentHealth = Mathf.FloorToInt(health.Value);
        currentEnergy = Mathf.FloorToInt(energy.Value);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnergy <= 0)
        {
            currentEnergy = 0;
            if(!isTired)
                isTired = true;
            Debug.Log("I am tired!");
        }
        else if(currentEnergy > 0 && isTired)
        {
            isTired = false;
        }
    }
}
