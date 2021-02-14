using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager _instance;

    bool deleteMode = false;

    private void Awake()
    {
        if(_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            LeftClickCompute();

        
    }

    public bool GetDeleteMode()
    {
        return this.deleteMode;
    }

    public void ToggleDeleteMode()
    {
        deleteMode = !deleteMode;
    }

    void LeftClickCompute()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!deleteMode)
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int targetInt = new Vector3Int(Mathf.FloorToInt(target.x), Mathf.FloorToInt(target.y), 0);

                //Grid._instance.GetTileDataAtClickedPosition(targetInt);
                if(!Grid._instance.GetTileDataAtClickedPosition(targetInt).isFull)
                    BuildManager._instance.InstantiateBuilding(targetInt);
            }
            else
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int targetInt = new Vector3Int(Mathf.FloorToInt(target.x), Mathf.FloorToInt(target.y), 0);
                //Grid._instance.RemoveTile(targetInt);
            }
        }
    }
}
