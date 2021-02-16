using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public bool isTired;
    public int energy;

    private int ironStock;

    public int IronStock { get => ironStock; }

    public void AddIronStock(int value)
    {
        this.ironStock += value;
    }

    public void DepleteIronStock(int value)
    {
        this.ironStock -= value;
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
