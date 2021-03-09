using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Stuff/Item")]
public class ItemBase : ScriptableObject
{
    public int id = -1;
    [SerializeField] string strindId;
    public string itemName = "New Item";
    public Sprite icon = null;

    private void OnValidate()
    {
        string path = UnityEditor.AssetDatabase.GetAssetPath(this);
        strindId = UnityEditor.AssetDatabase.AssetPathToGUID(path);
    }

    public virtual Item GetCopy()
    {
        Item item = new Item(this);
        return item;
    }
}
