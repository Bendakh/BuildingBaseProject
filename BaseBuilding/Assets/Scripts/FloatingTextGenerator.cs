using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextGenerator : MonoBehaviour
{
    public static FloatingTextGenerator _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }


    [SerializeField]
    private GameObject floatingTextPrefab;
    [SerializeField]
    private Transform floatingTextParent;


    public void InstantiateFloatingText(string textValue, Vector3 pos, Color color, TMPro.FontStyles fontStyle)
    {
        Vector3 randomOffset = new Vector3(0f, 1f, 0f);

        //Transform dmgNumber = Instantiate(damageNumberPrefab, pos + randomOffset, Quaternion.identity).transform;
        Transform dmgNumber = Instantiate(floatingTextPrefab, floatingTextParent).transform;
        dmgNumber.position = pos + randomOffset;
        dmgNumber.GetComponentInChildren<FloatingText>().Setup(textValue, color, fontStyle);
    }
}
