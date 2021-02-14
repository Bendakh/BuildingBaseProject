using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorScript : MonoBehaviour
{
    public bool isCursorActif = true;

    [SerializeField]
    GameObject cursorSprite;

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
        }
    }
}
