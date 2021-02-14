using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _instance;


    [SerializeField]
    GameObject selectedBuilding;

    public bool buildingSelected = true;

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
        Instantiate(selectedBuilding, targetPosition + new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
        Grid._instance.SetTileFull(targetPosition);
    }

    public void SetSelectedBuildable(GameObject buildablePrefab)
    {
        this.selectedBuilding = buildablePrefab;
    }
}
