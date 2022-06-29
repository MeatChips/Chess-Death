using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private Tile sandTile;
    [SerializeField] private Tile duneTile;

    [SerializeField] private Camera cam;

    public Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        Instance = this;
    }

    // Generating the grid
    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>(); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var randomTile = Random.Range(0,13) == 6 ? duneTile : sandTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                
                spawnedTile.Init(x,y);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

        GameManager.Instance.UpdateGameStates(GameState.SpawnBothTeams);
    }

    // Spawning the units on a random tile
    public Tile GetRandomTile(Team team)
    {
        if (team == Team.Blue)
            return tiles.Where(t => t.Key.x < width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
        // Blue Side
        else
            return tiles.Where(t => t.Key.x > width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
        // Red Side
    }

    // unitPosition = Position of tile unit is on
    // range = the range of the units how far it can move
    // tilePosition = the position of the tiles
    public List<Tile> GetTilesInRange(Vector2 unitPosition, int range)
    {
        List<Tile> resultList = new List<Tile>();

        foreach (Vector2 tilePosition in tiles.Keys)
        {
            if (Vector2.Distance(unitPosition, tilePosition) <= range)
            {
                resultList.Add(tiles[tilePosition]);
            }
        }

        return resultList;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}