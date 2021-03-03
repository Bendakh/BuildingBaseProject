using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftDatabaseManager : MonoBehaviour
{
    public static CraftDatabaseManager _instance;

    [SerializeField]
    private CraftRecipeDatabase craftRecipeDatabase;

    private void Awake()
    {
        _instance = this;   
    }
    

    public CraftRecipe GetRecipeById(int id)
    {
        CraftRecipe ret = craftRecipeDatabase.craftRecipeList[id];

        if(ret)
        {
            return ret;
        }
        else
        {
            Debug.LogError("There is no recipe with the id " + id);
            return null;
        }
    }
}
