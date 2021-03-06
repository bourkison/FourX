using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int Seed;
    public int WorldHeight = 5;
    public int WorldWidth = 10;
    World world;
    Player player;

    public GameObject TileContainer;
    public GameObject PlayerContainer;
    public GameObject InitColonyPrefab;
    
    public List<Tile> Tiles = new List<Tile>();
    public Material[] mats;
    public LayerMask ClickableTilesLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        if (Seed != 0)
        {
            UnityEngine.Random.InitState(Seed);
        }

        GenerateWorld();
        GeneratePlayer();
    }

    void GenerateWorld()
    {
        world = new World(WorldHeight, WorldWidth);
        Tile[] tiles = world.GetTiles();

        for (int i = 0; i < tiles.Length; i++)
        {
            Tile tile = tiles[i];
            int x = Mathf.FloorToInt(i / WorldHeight);
            int y = i % WorldHeight;

            GameObject go = BuildTile(tile.Fertility);
            go.name = x.ToString() + "|" + y.ToString();
            go.transform.SetParent(TileContainer.transform);
            Vector3 pos = new Vector3(x, y, 0);
            go.transform.position = pos;
            
            ClickableTile ct = go.AddComponent<ClickableTile>();
            ct.SetTile(tile);
        }
    }

    void GeneratePlayer()
    {
        int colX = Mathf.FloorToInt(UnityEngine.Random.Range(0, WorldWidth));
        int colY = Mathf.FloorToInt(UnityEngine.Random.Range(0, WorldHeight));
        Vector3 colPos = new Vector3(colX, colY, 0);

        player = new Player(colPos);

        GameObject go = Instantiate(InitColonyPrefab, colPos + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
        go.transform.SetParent(TileContainer.transform);

    }

    // Update is called once per frame
    GameObject BuildTile(int fertility)
    {
        GameObject go = new GameObject();
        MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
        MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        MeshCollider mc = go.AddComponent(typeof(MeshCollider)) as MeshCollider;

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
        mc.sharedMesh = m;
        m.RecalculateBounds();
        m.RecalculateNormals();

        return go;
    }
}