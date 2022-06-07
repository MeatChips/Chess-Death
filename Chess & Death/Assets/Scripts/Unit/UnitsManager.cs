using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public static UnitsManager Instance;

    private List<ScriptableUnit> _units;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    // Volgende keer voor elke verschillende troep een function schrijven zoals deze hieronder. Omdat ik het anders niet weet.
    public void SpawnBlue()
    {
        var blueGeneralCount = 1;

        for (int i = 0; i < blueGeneralCount; i++)
        {
            var blueGeneralPrefab = GetUnit<BaseBlueG>(TeamUnits.BlueGeneral);
            var spawnedBlueGeneral = Instantiate(blueGeneralPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueGeneralSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueGeneral);
        }

        GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
    }

    public void SpawnRed()
    {
        var redGeneralCount = 1;

        for (int i = 0; i < redGeneralCount; i++)
        {
            var redGeneralPrefab = GetUnit<BaseRedG>(TeamUnits.RedGeneral);
            var spawnedRedGeneral = Instantiate(redGeneralPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedGeneralSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedGeneral);
        }

        //GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
    }

    private T GetUnit<T>(TeamUnits teamUnits) where T: BaseUnit
    {
        return (T)_units.Where(u => u.TeamUnits == teamUnits).OrderBy(o => Random.value).First().UnitPrefab;
    }
}
