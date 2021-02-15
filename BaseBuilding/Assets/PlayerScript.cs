using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

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
        
    }
}
