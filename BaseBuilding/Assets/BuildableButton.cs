using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BuildableButton : MonoBehaviour
{
    [SerializeField]
    GameObject buildable;

    [SerializeField]
    Button buildableButton;

    private void Start()
    {
        InitializeButton();
    }

    public void ChooseTile()
    {
        BuildManager._instance.SetSelectedBuildable(buildable);
    }

    private void InitializeButton()
    {
        buildableButton.GetComponent<Image>().sprite = buildable.GetComponent<SpriteRenderer>().sprite;
        buildableButton.onClick.AddListener(() => ChooseTile());
    }


}
