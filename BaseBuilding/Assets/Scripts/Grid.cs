using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid : MonoBehaviour
{
    public static Grid _instance;

    [SerializeField]
    Tile cursorTile;

    [SerializeField]
    public Tilemap tileMap;

    [SerializeField]
    public Tilemap informationTileMap;

    public Dictionary<Vector3, TileData> tilesList = new Dictionary<Vector3, TileData>();
    private bool tilesComputed = false;

    //[SerializeField]
    //private Tile activeTile;

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

        ComputeTiles();
        //DisplayTiles();
    }

  

    void ComputeTiles()
    {
        if(!tilesComputed)
        {
            foreach(Vector3Int pos in tileMap.cellBounds.allPositionsWithin)
            {
                Vector3Int temp = new Vector3Int(pos.x, pos.y, pos.z);
                if (!tileMap.HasTile(temp)) continue;
                Vector3 worldPos = tileMap.CellToWorld(temp);
                TileData tempTileData = new TileData((Vector2Int) temp, worldPos, tileMap.GetTile(temp));
                tilesList.Add(worldPos, tempTileData);
            }
            tilesComputed = true;
        }
    }

    public TileData GetTileDataAtClickedPosition(Vector3Int mousePosition)
    {
        //We'll return this later
        TileData toReturn;


        if (tilesList.TryGetValue(mousePosition, out toReturn))
        {
            Debug.Log(("Grid position" + toReturn.pos + " World position: " + toReturn.worldPos + "\n"));
            return toReturn;
        }
        else
        {
            return null;
        }
    }

    public void SetTileFull(Vector3Int targetPosition)
    {
        TileData targetTile;
        if(tilesList.TryGetValue(targetPosition, out targetTile))
        {
            targetTile.SetTileFull();
        }

    }

    /*public void SetActiveTile(Tile tile)
    {
        if (InputManager._instance.GetDeleteMode())
            InputManager._instance.ToggleDeleteMode();
        this.activeTile = tile;
    }*/

    void DisplayTiles()
    {
        foreach (KeyValuePair<Vector3, TileData> td in tilesList)
        {
            Debug.Log("Grid pos: " + td.Value.pos + " World pos: " + td.Value.worldPos);
        }
    }

    /*public void PlaceTile(Vector3Int pos)
    {
        if (activeTile != null)
        {
            tileMap.SetTile(pos, activeTile);
            Vector3 worldPos = tileMap.CellToWorld(pos);
            TileData temp = new TileData((Vector2Int) pos, worldPos, activeTile);
            tilesList.Add(worldPos, temp);
        }
    }*/

    /*public void RemoveTile(Vector3Int pos)
    {
        if (tileMap.HasTile(pos))
        {
            tileMap.SetTile(pos, null);
            Vector3 worldPos = tileMap.CellToWorld(pos);
            tilesList.Remove(worldPos);
        }
    }*/

}
