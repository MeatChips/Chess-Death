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
    public void SpawnBlueGeneral()
    {
        // BLUE GENERAL
        var blueGeneralCount = 1;

        for (int i = 0; i < blueGeneralCount; i++)
        {
            var blueGeneralPrefab = GetUnit<BaseBlueG>(TeamUnits.BlueGeneral);
            var spawnedBlueGeneral = Instantiate(blueGeneralPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueGeneralSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueGeneral);
        }

        // BLUE RIFLEMAN
        var blueRiflemanCount = 1;

        for (int i = 0; i < blueRiflemanCount; i++)
        {
            var blueRiflemanPrefab = GetUnit<BaseBlueRM>(TeamUnits.BlueRifleman);
            var spawnedBlueRifleman = Instantiate(blueRiflemanPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueRiflemanSpawnTile();
        
            randomSpawnTile.SetUnit(spawnedBlueRifleman);
        }

        // BLUE MINIGUNNER
        var blueMinigunnerCount = 1;

        for (int i = 0; i < blueMinigunnerCount; i++)
        {
            var blueMinigunnerPrefab = GetUnit<BaseBlueMG>(TeamUnits.BlueMinigunner);
            var spawnedBlueMinigunner = Instantiate(blueMinigunnerPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueMinigunnerSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueMinigunner);
        }

        // BLUE SNIPER
        var blueSniperCount = 1;

        for (int i = 0; i < blueSniperCount; i++)
        {
            var blueSniperPrefab = GetUnit<BaseBlueSR>(TeamUnits.BlueSniper);
            var spawnedBlueSniper = Instantiate(blueSniperPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueSniperSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueSniper);
        }

        // BLUE SHOTGUNNER
        var blueShotgunnerCount = 1;

        for (int i = 0; i < blueShotgunnerCount; i++)
        {
            var blueShotgunnerPrefab = GetUnit<BaseBlueSG>(TeamUnits.BlueShotgunner);
            var spawnedBlueShotgunner = Instantiate(blueShotgunnerPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueShotgunnerSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueShotgunner);
        }

        // BLUE SCOUT
        var blueScoutCount = 1;

        for (int i = 0; i < blueScoutCount; i++)
        {
            var blueScoutPrefab = GetUnit<BaseBlueS>(TeamUnits.BlueScout);
            var spawnedBlueScout = Instantiate(blueScoutPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueScoutSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueScout);
        }

        // BLUE GRENADE THROWER
        var blueGrenadeThrower = 1;

        for (int i = 0; i < blueGrenadeThrower; i++)
        {
            var blueGrenadeThrowerPrefab = GetUnit<BaseBlueGT>(TeamUnits.BlueGrenadeThrower);
            var spawnedBlueGrenadeThrower = Instantiate(blueGrenadeThrowerPrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueGrenadeThrowerSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueGrenadeThrower);
        }

        // BLUE ARMORED VEHICLE
        var blueArmoredVehicle = 1;

        for (int i = 0; i < blueArmoredVehicle; i++)
        {
            var blueArmoredVehiclePrefab = GetUnit<BaseBlueAV>(TeamUnits.BlueArmoredVehicle);
            var spawnedBlueArmoredVehicle = Instantiate(blueArmoredVehiclePrefab);
            var randomSpawnTile = GridManager.Instance.GetBlueArmoredVehicleSpawnTile();

            randomSpawnTile.SetUnit(spawnedBlueArmoredVehicle);
        }

        GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
    }

    public void SpawnRedGeneral()
    {
        // RED GENERAL
        var redGeneralCount = 1;

        for (int i = 0; i < redGeneralCount; i++)
        {
            var redGeneralPrefab = GetUnit<BaseRedG>(TeamUnits.RedGeneral);
            var spawnedRedGeneral = Instantiate(redGeneralPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedGeneralSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedGeneral);
        }

        // RED RIFLEMAN
        var redRiflemanCount = 1;

        for (int i = 0; i < redRiflemanCount; i++)
        {
            var redRiflemanPrefab = GetUnit<BaseRedRM>(TeamUnits.RedRifleman);
            var spawnedRedRifleman = Instantiate(redRiflemanPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedRiflemanSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedRifleman);
        }

        // RED MINIGUNNER
        var redMinigunnerCount = 1;

        for (int i = 0; i < redMinigunnerCount; i++)
        {
            var redMinigunnerPrefab = GetUnit<BaseRedMG>(TeamUnits.RedMinigunner);
            var spawnedRedMinigunner = Instantiate(redMinigunnerPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedMinigunnerSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedMinigunner);
        }

        // RED SNIPER
        var redSniperCount = 1;

        for (int i = 0; i < redSniperCount; i++)
        {
            var redSniperPrefab = GetUnit<BaseRedSR>(TeamUnits.RedSniper);
            var spawnedRedSniper = Instantiate(redSniperPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedSniperSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedSniper);
        }

        // RED SHOTGUNNER
        var redShotgunnerCount = 1;

        for (int i = 0; i < redShotgunnerCount; i++)
        {
            var redShotgunnerPrefab = GetUnit<BaseRedSG>(TeamUnits.RedShotgunner);
            var spawnedRedShotgunner = Instantiate(redShotgunnerPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedShotgunnerSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedShotgunner);
        }

        // RED SCOUT
        var redScoutCount = 1;

        for (int i = 0; i < redScoutCount; i++)
        {
            var redScoutPrefab = GetUnit<BaseRedS>(TeamUnits.RedScout);
            var spawnedRedScout = Instantiate(redScoutPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedScoutSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedScout);
        }

        // RED GRENADE THROWER
        var redGrenadeThrower = 1;

        for (int i = 0; i < redGrenadeThrower; i++)
        {
            var redGrenadeThrowerPrefab = GetUnit<BaseRedGT>(TeamUnits.RedGrenadeThrower);
            var spawnedRedGrenadeThrower = Instantiate(redGrenadeThrowerPrefab);
            var randomSpawnTile = GridManager.Instance.GetRedGrenadeThrowerSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedGrenadeThrower);
        }

        // RED ARMORED VEHICLE
        var redArmoredVehicle = 1;

        for (int i = 0; i < redArmoredVehicle; i++)
        {
            var redArmoredVehiclePrefab = GetUnit<BaseRedAV>(TeamUnits.RedArmoredVehicle);
            var spawnedRedArmoredVehicle = Instantiate(redArmoredVehiclePrefab);
            var randomSpawnTile = GridManager.Instance.GetRedArmoredVehicleSpawnTile();

            randomSpawnTile.SetUnit(spawnedRedArmoredVehicle);
        }

        //GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
    }

    private T GetUnit<T>(TeamUnits teamUnits) where T : BaseUnit
    {
        return (T)_units.Where(u => u.TeamUnits == teamUnits).OrderBy(o => Random.value).First().UnitPrefab;
    }
}

//public void SpawnBlue()
//{
//    var blueGeneralCount = 1;
//    var blueRiflemanCount = 1;
//    //var blueMinigunnerCount = 1;
//    //var blueSniperCount = 1;
//    //var blueShotgunnerCount = 1;
//    //var blueScoutCount = 1;
//    //var blueGrenadeThrower = 1;
//    //var blueArmoredVehicle = 1;
//
//    for (int i = 0; i < blueGeneralCount; i++)
//    {
//        var blueGeneralPrefab = GetUnit<BaseBlueG>(TeamUnits.BlueGeneral);
//        var spawnedBlueGeneral = Instantiate(blueGeneralPrefab);
//        var randomSpawnTile = GridManager.Instance.GetBlueRandomSpawnTile();
//
//        randomSpawnTile.SetUnit(spawnedBlueGeneral);
//    }
//
//    for (int i = 0; i < blueRiflemanCount; i++)
//    {
//        var blueRiflemanPrefab = GetUnit<BaseBlueRM>(TeamUnits.BlueRifleman);
//        var spawnedBlueRifleman = Instantiate(blueRiflemanPrefab);
//        var randomSpawnTile = GridManager.Instance.GetBlueRandomSpawnTile();
//
//        randomSpawnTile.SetUnit(spawnedBlueRifleman);
//    }
//
//    GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
//}

//public void SpawnRed()
//{
//    var redGeneralCount = 1;
//    var redRiflemanCount = 1;
//    //var redMinigunnerCount = 1;
//    //var redSniperCount = 1;
//    //var redShotgunnerCount = 1;
//    //var redScoutCount = 1;
//    //var redGrenadeThrower = 1;
//    //var redArmoredVehicle = 1;
//
//    for (int i = 0; i < redGeneralCount; i++)
//    {
//        var redGeneralPrefab = GetUnit<BaseRedG>(TeamUnits.RedRifleman);
//        var spawnedRedGeneral = Instantiate(redGeneralPrefab);
//        var randomSpawnTile = GridManager.Instance.GetRedRandomSpawnTile();
//
//        randomSpawnTile.SetUnit(spawnedRedGeneral);
//    }
//
//    for (int i = 0; i < redRiflemanCount; i++)
//    {
//        var redRiflemanPrefab = GetUnit<BaseRedRM>(TeamUnits.RedGeneral);
//        var spawnedRedRifleman = Instantiate(redRiflemanPrefab);
//        var randomSpawnTile = GridManager.Instance.GetRedRandomSpawnTile();
//
//        randomSpawnTile.SetUnit(spawnedRedRifleman);
//    }
//
//    //GameManager.Instance.UpdateGameStates(GameState.SpawnRed);
//}
