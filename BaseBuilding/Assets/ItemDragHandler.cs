using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler 
{
    Vector3 initialPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
       /* RectTransform shortCut = 
        if (RectTransformUtility.RectangleContainsScreenPoint(UIManager._instance.InventoryShortcuts. , Input.mousePosition)) ;*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform shortCut = UIManager._instance.InventoryShortcuts.GetHoveredShortcut();
        Debug.Log(shortCut);
        if (shortCut != null)
        {
            shortCut.GetComponent<InventoryShortcutSlot>().SetStockedItem(GetComponent<ItemSlot>().ItemStocked);
            transform.localPosition = initialPosition;
        }
        else
            transform.localPosition = initialPosition;    
    }
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
