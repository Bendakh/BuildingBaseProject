using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    [SerializeField] ItemBase collectableItem;

    private void Collect()
    {
        GameManager._instance.Player.GetInventory().AddItem(collectableItem.GetCopy());
        Destroy(this.gameObject);
    }

    public override void Interact()
    {
        base.Interact();
        Collect();
    }
}
