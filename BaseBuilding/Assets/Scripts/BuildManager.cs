using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;


    [SerializeField]
    GameObject selectedBuilding = null;

    public GameObject SelectedBuilding { get => selectedBuilding; }

    public bool buildingSelected = false;

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

    public void InstantiateBuilding(Vector3Int targetPosition)
    {
        if (selectedBuilding.GetComponent<Building>().CanBuild(GameManager._instance.Player.GetInventory()))
        {
            GameObject newBuilding = Instantiate(selectedBuilding, targetPosition + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
            newBuilding.SendMessage("Build", GameManager._instance.Player.GetInventory());
            Grid._instance.SetTileFull(targetPosition);
        }
    }

    public void SetSelectedBuildable(GameObject buildablePrefab)
    {
        this.selectedBuilding = buildablePrefab;
        this.buildingSelected = true;

        CursorScript._instance.SetOptionalCursorSprite(buildablePrefab.GetComponent<SpriteRenderer>().sprite);
    }

    public void SetNoSelectedBuildable()
    {
        this.selectedBuilding = null;
        this.buildingSelected = false;
    }
}
