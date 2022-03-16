using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    int worldHeight = 5;
    int worldWidth = 5;
    World world;
    public GameObject WorldContainer;
    public List<Tile> Tiles = new List<Tile>();
    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        world = new World(worldHeight, worldWidth);
        Tile[] tiles = world.GetTiles();

        for (int i = 0; i < tiles.Length; i++)
        {
            Tile tile = tiles[i];
            int x = Mathf.FloorToInt(i / worldHeight);
            int y = i % worldWidth;

            GameObject go = BuildTile(tile.Fertility);
            go.name = x.ToString() + ", " + y.ToString();
            go.transform.SetParent(WorldContainer.transform);
            Vector3 pos = new Vector3(x, y, 0);
            go.transform.position = pos;
        }
    }

    // Update is called once per frame
    GameObject BuildTile(int fertility)
    {
        GameObject go = new GameObject();
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        if (fertility < 50)
        {
            mr.material = mats[0];
        }
        else 
        {
            mr.material = mats[1];
        }

        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 0)
        };

        m.uv = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };

        m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        mf.mesh = m;
        m.RecalculateBounds();
        m.RecalculateNormals();

        return go;
    }
}