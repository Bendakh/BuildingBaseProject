using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isTired;
    public int energy;

    private int ironStock;
    private int woodStock;
    private int grassStock;

    public int IronStock { get => ironStock; }
    public int WoodStock { get => woodStock; }

    public void AddIronStock(int value)
    {
        this.ironStock += value;
    }

    public void AddWoodStock(int value)
    {
        this.woodStock += value;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(energy <= 0)
        {
            energy = 0;
            if(!isTired)
                isTired = true;
            Debug.Log("I am tired!");
        }
        else if(energy > 0 && isTired)
        {
            isTired = false;
        }
    }
}
