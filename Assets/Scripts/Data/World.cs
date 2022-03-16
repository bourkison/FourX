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

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int fertility = Mathf.FloorToInt(UnityEngine.Random.Range(0, 100));
                tiles.Add(new Tile(fertility));
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

}
