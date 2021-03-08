using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIWindow : MonoBehaviour
{
    [SerializeField] private Vector2 closedPosition;
    [SerializeField] private Vector2 openedPosition;


    [SerializeField] private bool horizontalWindow;
    [SerializeField] private bool verticalWindow;

    [SerializeField] private float delay;

    public void DisplayHide(bool isOpen)
    {
        if(isOpen)
        {
            OpenWindow();
        }
        else
        {
            CloseWindow();
        }
    }

    private void OpenWindow()
    {
        if (!LeanTween.isTweening(this.gameObject.GetComponent<RectTransform>()))
        { 
            if (horizontalWindow)
            {
                LeanTween.moveX(this.gameObject.GetComponent<RectTransform>(), openedPosition.x, delay).setEase(LeanTweenType.easeOutBack);
            }

            if (verticalWindow)
            {
                LeanTween.moveY(this.gameObject.GetComponent<RectTransform>(), openedPosition.y, delay).setEase(LeanTweenType.easeOutBack);
            }
        }
    }

    private void CloseWindow()
    {
        if(!LeanTween.isTweening(this.gameObject.GetComponent<RectTransform>()))
        {
            if (horizontalWindow)
            {
                LeanTween.moveX(this.gameObject.GetComponent<RectTransform>(), closedPosition.x, delay).setEase(LeanTweenType.easeOutBack);
            }

            if (verticalWindow)
            {
                LeanTween.moveY(this.gameObject.GetComponent<RectTransform>(), closedPosition.y, delay).setEase(LeanTweenType.easeOutBack);
            }
        }
    }
 
}
