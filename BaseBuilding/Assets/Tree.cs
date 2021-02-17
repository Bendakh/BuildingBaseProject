using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Interactable
{

    public int currentYield = 9999;

    [SerializeField]
    Sound woodChopSoundEffect;

    public override void Interact()
    {
        if(isInteractable)
        {
            base.Interact();
            //AudioManager._instance.PlaySound(woodChopSoundEffect);
            GameManager._instance.AddRessource(RessourceType.WOOD, 10);
            currentYield -= 10;
            FloatingTextGenerator._instance.InstantiateFloatingText("+" + 10 + " wood", transform.position, Color.black, TMPro.FontStyles.Bold);
            GameManager._instance.DepletePlayerEnergy(5);
        }      
    }
}
