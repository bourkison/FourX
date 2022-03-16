using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Player(Vector3 pos)
    {
        this.colonies = new List<Colony>();
        this.colonies.Add(new Colony(pos));
    }

    List<Colony> colonies;

    public void AddColony(Vector3 pos)
    {
        this.colonies.Add(new Colony(pos));
    }
}
