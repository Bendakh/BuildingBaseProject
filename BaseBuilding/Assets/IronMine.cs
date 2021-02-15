using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMine : Interactable
{
    public float interactionCooldown;

    public int currentYield = 9999;
   

    [SerializeField]
    private Sound mineSoundEffect;

    public override void Interact()
    {
        if (isInteractable)
        {
            base.Interact();
            AudioManager._instance.PlaySound(mineSoundEffect);
            GameManager._instance.AddRessource(RessourceType.IRON, 10);
            currentYield -= 10;
        }
    }
}
