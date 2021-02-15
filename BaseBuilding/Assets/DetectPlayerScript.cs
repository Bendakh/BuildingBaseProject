using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerScript : MonoBehaviour
{

    [SerializeField]
    Interactable interactableParent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            interactableParent.SetIsInteractable(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            interactableParent.SetIsInteractable(false);
    }
}
