using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Image energyBar;

    [SerializeField]
    TextMeshProUGUI ironStockValue;

    [SerializeField]
    TextMeshProUGUI woodStockValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.fillAmount = (float) GameManager._instance.Player.energy / 100f;
        ironStockValue.text = GameManager._instance.Player.IronStock.ToString();
        woodStockValue.text = GameManager._instance.Player.WoodStock.ToString();
    }
}
