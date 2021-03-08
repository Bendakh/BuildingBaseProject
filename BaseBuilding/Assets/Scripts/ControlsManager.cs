using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    [SerializeField] UIWindow craftingWindow;
    [SerializeField] UIWindow buildingWindow;

    bool isCraftingWindowOpened = false;
    bool isBuildingWindowOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        //craftingWindowAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            DisplayHideCraftingWindow();
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            DisplayHideBuildingWindow();
        }
    }

    void DisplayHideCraftingWindow()
    {
        isCraftingWindowOpened = !isCraftingWindowOpened;
        craftingWindow.DisplayHide(isCraftingWindowOpened);
    }

    void DisplayHideBuildingWindow()
    {
        isBuildingWindowOpened = !isBuildingWindowOpened;
        buildingWindow.DisplayHide(isBuildingWindowOpened);
    }
}
