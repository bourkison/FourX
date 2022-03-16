using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    public World(int height, int width)
    {
        tiles = new List<Tile>();
        this.height = height;
        this.width = width;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int fertility = Mathf.FloorToInt(UnityEngine.Random.Range(0, 100));
                Vector3 pos = new Vector3(x, y, 0);
                tiles.Add(new Tile(fertility, pos));
            }
        }
    }

    List<Tile> tiles;
    int height;
    int width;

    public Tile[] GetTiles()
    {
        return tiles.ToArray();
    }

    public Tile GetTileAtIndex(int index)
    {
        return tiles[index];
    }

}
