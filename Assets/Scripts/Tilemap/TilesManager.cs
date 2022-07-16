using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;
using System.Linq;


public class TilesManager : MonoBehaviour
{
    public static TilesManager Instance;

    [SerializeField] public Tile cell;
    [SerializeField] private Vector2 x_v = new Vector2(1, 0);
    [SerializeField] private Vector2 y_v = new Vector2(0, 1);
    [SerializeField] private int board_size = 5;
    private Dictionary<Vector2, Tile> _grid;   

    void Awake() {
        Instance = this;
    }

    public void GenerateGrid() {
        _grid = new Dictionary<Vector2, Tile>();
        var offset = -board_size * (x_v + y_v) / 2;
        for (var i = 0; i < board_size; i++)
            for (var j = 0; j < board_size; j++) {
                Debug.Log(i.ToString() + " " + j.ToString());
                var tile = Instantiate(cell, offset + x_v * i + y_v * j, Quaternion.identity);
                tile.name = $"Tile {i - board_size} {j - board_size}";
                tile.Init(i - board_size, j - board_size, false, false, (Random.value>0.9f));
                _grid[new Vector2(i - board_size, j - board_size)] = tile;
                }    
    }


    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.DrawIcon(transform.position, "Light Gizmo.tiff", true);
    }

    public List<Tile> GetAllTiles() {
        return _grid.Values.ToList();;
    }

    public Tile GetTile(Vector2 pos) {
        if (_grid.TryGetValue(pos, out var tile)) {
            return tile;
        }
        return null;
    }

    void Start()
    {
        GenerateGrid(); 
    }

    void Update()
    {
    }
}