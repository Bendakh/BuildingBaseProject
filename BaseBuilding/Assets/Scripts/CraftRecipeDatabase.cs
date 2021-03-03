using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftRecipeDatabse", menuName = "Stuff/Craft Database")]
public class CraftRecipeDatabase : ScriptableObject
{
    public List<CraftRecipe> craftRecipeList;
}
