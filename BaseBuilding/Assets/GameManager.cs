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
        player.AddIronStock(value);
    }
}
