using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    Tile tile;

    void OnMouseDown() 
    {
        Debug.Log(tile.Position);
        Debug.Log(transform.name);
    }

    public void SetTile(Tile tile)
    {
        this.tile = tile;
    }
}
