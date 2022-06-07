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

    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Camera cam;

    private Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>(); 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); 
                spawnedTile.Init(isOffset);

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);

        GameManager.Instance.UpdateGameStates(GameState.SpawnBlue);
    }

    // Blue 1 - GENERAL
    public Tile GetBlueGeneralSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 2 - RIFLEMAN
    public Tile GetBlueRiflemanSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 3 - MINIGUNNER
    public Tile GetBlueMinigunnerSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 4 - SNIPER
    public Tile GetBlueSniperSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 5 - SHOTGUNNER
    public Tile GetBlueShotgunnerSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 6 - SCOUT
    public Tile GetBlueScoutSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 7 - GRENADE THROWER
    public Tile GetBlueGrenadeThrowerSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Blue 8 - ARMORED VEHICLE
    public Tile GetBlueArmoredVehicleSpawnTile()
    {
        return tiles.Where(t => t.Key.x < width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // #############################################################################################################

    // Red 1 - GENERAL
    public Tile GetRedGeneralSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 2 - RIFLEMAN
    public Tile GetRedRiflemanSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 3 - MINIGUNNER
    public Tile GetRedMinigunnerSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 4 - SNIPER
    public Tile GetRedSniperSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 5 - SHOTGUNNER
    public Tile GetRedShotgunnerSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 6 - SCOUT
    public Tile GetRedScoutSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 7 - GRENADE THROWER
    public Tile GetRedGrenadeThrowerSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    // Red 8 - ARMORED VEHICLE
    public Tile GetRedArmoredVehicleSpawnTile()
    {
        return tiles.Where(t => t.Key.x > width / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
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
