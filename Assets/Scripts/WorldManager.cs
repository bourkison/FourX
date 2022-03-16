using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private int WorldHeight = 5;
    private int WorldWidth = 5;
    public GameObject WorldContainer;
    public List<Tile> Tiles;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < WorldHeight; i++)
        {
            for (int j = 0; j < WorldWidth; j++)
            {
                // Tile tile = new Tile(10);
                // Tiles.Add(tile);

                GameObject go = BuildTile();
                go.name = i.ToString() + ", " + j.ToString();
                go.transform.SetParent(WorldContainer.transform);
                Vector3 pos = new Vector3(i, j, 0);
                go.transform.position = pos;
            }
        }
    }

    // Update is called once per frame
    GameObject BuildTile(int height = 1, int width = 1)
    {
        GameObject go = new GameObject();
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;

        Mesh m = new Mesh();
        m.vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(width, 0, 0),
            new Vector3(width, height, 0),
            new Vector3(0, height, 0)
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