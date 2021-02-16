using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{

    private TextMeshPro damageText;

    private void Awake()
    {
        damageText = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(string textValue, Color color, FontStyles fontStyle)
    {
        damageText.SetText(textValue);
        damageText.color = color;
        damageText.fontStyle = fontStyle;
    }
}