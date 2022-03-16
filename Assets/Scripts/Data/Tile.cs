using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Tile(int fertility, Vector3 position)
    {
        this.Fertility = fertility;
        this.Position = position;
    }
    public int Fertility { get; protected set; } // 100 = fertile, 0 = desert
    public Vector3 Position { get; protected set; }
}
