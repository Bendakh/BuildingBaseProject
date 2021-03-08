using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour
{
    public static CursorScript _instance;

    public bool isCursorActif = true;
    public bool isCursorOptionalImageDisplayed = false;

    [SerializeField]
    GameObject cursorSprite;

    [SerializeField]
    GameObject cursorOptionalImage;

    private void Awake()
    {
        if (_instance == null)
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
        if (EventSystem.current.IsPointerOverGameObject() && isCursorActif)
        {
            cursorSprite.SetActive(false);
            isCursorActif = false;
        }
        else if(!EventSystem.current.IsPointerOverGameObject() && !isCursorActif)
        {
            cursorSprite.SetActive(true);
            isCursorActif = true;
        }


        if (isCursorActif)
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int targetInt = new Vector3Int(Mathf.FloorToInt(target.x), Mathf.FloorToInt(target.y), 0);

            cursorSprite.transform.position = targetInt + new Vector3(0.5f, 0.5f, 0f);

            if(cursorOptionalImage.activeInHierarchy)
                cursorOptionalImage.transform.position = cursorSprite.transform.position;

            if (BuildManager._instance.buildingSelected && !cursorOptionalImage.activeInHierarchy)
            {
                cursorOptionalImage.SetActive(true);
                cursorOptionalImage.GetComponent<SpriteRenderer>().sprite = BuildManager._instance.SelectedBuilding.GetComponent<SpriteRenderer>().sprite;
                Color temp = cursorOptionalImage.GetComponent<SpriteRenderer>().color;
                temp.a = 0.5f;
                cursorOptionalImage.GetComponent<SpriteRenderer>().color = temp;     
            }
            else if(!BuildManager._instance.buildingSelected)
            {
                cursorOptionalImage.SetActive(false);
            }
        }        
    }

    public void SetOptionalCursorSprite(Sprite sprite)
    {
        cursorOptionalImage.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
