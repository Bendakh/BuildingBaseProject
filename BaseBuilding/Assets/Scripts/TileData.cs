using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData 
{
    public Vector2Int pos;
    public Vector3 worldPos;
    public TileBase tileAsset;

    public bool isFull;
    public GameObject content;

    public TileData(Vector2Int pos, Vector3 worldPos, TileBase tileAsset)
    {
        this.pos = pos;
        this.worldPos = worldPos;
        this.tileAsset = tileAsset;
    }

    public TileData(Vector2Int pos, Vector3 worldPos, TileBase tileAsset, bool isFull, GameObject content)
    {
        this.pos = pos;
        this.worldPos = worldPos;
        this.tileAsset = tileAsset;
        this.isFull = isFull;
        this.content = content;
    }

    public void SetTileFull()
    {
        this.isFull = true;
    }
}
