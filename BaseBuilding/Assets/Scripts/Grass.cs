using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Interactable
{

    public int currentYield = 999;

    [SerializeField] Sound grassCuttingSoundEffect;

    public int energyCost;
    
    public override void Interact()
    {
        if(isInteractable && GameManager._instance.Player.CurrentEnergy >= this.energyCost)
        {
            base.Interact();
            //AudioManager._instance.PlaySound(grassCuttingSoundEffect);
            GameManager._instance.AddRessource(RessourceType.GRASS, 10);
            currentYield -= 10;
            FloatingTextGenerator._instance.InstantiateFloatingText("+" + 10 + " grass", transform.position, Color.black, TMPro.FontStyles.Bold);
            GameManager._instance.DepletePlayerEnergy(energyCost);
        }
    }
}
