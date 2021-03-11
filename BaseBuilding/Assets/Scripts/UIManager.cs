using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    [SerializeField] Image energyBar;

    [SerializeField] TextMeshProUGUI ironStockValue;
    [SerializeField] TextMeshProUGUI woodStockValue;
    [SerializeField] TextMeshProUGUI grassStockValue;

    [SerializeField] TextMeshProUGUI errorMessages;

    [SerializeField] ToolTipPanel toolTipPanel;

    [SerializeField] InventoryShortcuts inventoryShortcuts;

    public InventoryShortcuts InventoryShortcuts { get => inventoryShortcuts; } 

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.fillAmount = (float) GameManager._instance.Player.CurrentEnergy / 100f;
        ironStockValue.text = GameManager._instance.Player.IronStock.ToString();
        woodStockValue.text = GameManager._instance.Player.WoodStock.ToString();
        grassStockValue.text = GameManager._instance.Player.GrassStock.ToString();
    }

    public void SetErrorMessage(string errorMessage)
    {
        errorMessages.text = errorMessage;
        StartCoroutine(ResetErrorMessages(2f));
    }

    public void DisplayToolTipPanel(Item item)
    {
        toolTipPanel.gameObject.SetActive(true);
        toolTipPanel.DisplayToolTipPanel(item);
    }

    public void HideToolTipPanel()
    {
        toolTipPanel.ResetToolTipPanel();
        toolTipPanel.gameObject.SetActive(false);
    }

    IEnumerator ResetErrorMessages(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorMessages.text = "";
    }
}
