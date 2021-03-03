using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{

    private TextMeshPro floatingText;

    private void Awake()
    {
        floatingText = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(string textValue, Color color, FontStyles fontStyle)
    {
        floatingText.SetText(textValue);
        floatingText.color = color;
        floatingText.fontStyle = fontStyle;
    }
}