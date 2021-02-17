using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RessourceType
{
    IRON,
    WOOD,
    GRASS
}



public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField]
    PlayerScript player;

    public PlayerScript Player { get => player; }

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddRessource(RessourceType ressourceType, int value)
    {
        if(ressourceType == RessourceType.IRON)
            player.AddIronStock(value);
        if (ressourceType == RessourceType.WOOD)
            player.AddWoodStock(value);
    }

    public void DepletePlayerEnergy(int energyToDeplete)
    {
        this.player.energy -= energyToDeplete;
    }
}
