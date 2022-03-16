using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Tile(int fertility)
    {
        this.Fertility = fertility;
    }
    public int Fertility { get; protected set; } // 100 = fertile, 0 = desert
}
