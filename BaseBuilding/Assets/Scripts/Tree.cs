using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactable
{

    public int currentYield = 9999;

    [SerializeField]
    Sound woodChopSoundEffect;
    public int energyCost;
    public override void Interact()
    {
        if(isInteractable && GameManager._instance.Player.CurrentEnergy >= this.energyCost)
        {
            base.Interact();
            //AudioManager._instance.PlaySound(woodChopSoundEffect);
            GameManager._instance.AddRessource(RessourceType.WOOD, 10);
            currentYield -= 10;
            FloatingTextGenerator._instance.InstantiateFloatingText("+" + 10 + " wood", transform.position, Color.black, TMPro.FontStyles.Bold);
            GameManager._instance.DepletePlayerEnergy(energyCost);
        }      
    }
}
