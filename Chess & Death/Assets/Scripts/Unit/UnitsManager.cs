using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    public static UnitsManager Instance;

    private List<ScriptableUnit> _units;

    public BaseBlueG SelectedBlueGeneral;
    public BaseRedG SelectedRedGeneral;

    void Awake()
    {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    // Spawning the units
    public void SpawnUnits()
    {
        // The last number is used for how many units
        Spawn(Team.Blue, UnitType.General, 1);
        Spawn(Team.Blue, UnitType.Rifleman, 1);
        Spawn(Team.Blue, UnitType.Minigunner, 1);
        Spawn(Team.Blue, UnitType.Sniper, 1);
        Spawn(Team.Blue, UnitType.Shotgunner, 1);
        Spawn(Team.Blue, UnitType.Scout, 5);
        Spawn(Team.Blue, UnitType.GrenadeThrower, 1);
        Spawn(Team.Blue, UnitType.ArmoredVehicle, 1);

        Spawn(Team.Red, UnitType.General, 1);
        Spawn(Team.Red, UnitType.Rifleman, 1);
        Spawn(Team.Red, UnitType.Minigunner, 1);
        Spawn(Team.Red, UnitType.Sniper, 1);
        Spawn(Team.Red, UnitType.Shotgunner, 1);
        Spawn(Team.Red, UnitType.Scout, 1);
        Spawn(Team.Red, UnitType.GrenadeThrower, 1);
        Spawn(Team.Red, UnitType.ArmoredVehicle, 1);

        GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
    }

    private void Spawn(Team team, UnitType unitType, int number)
    {
        var prefab = GetUnit<BaseUnit>(team, unitType);
        for (int i = 0; i < number; i++)
        {
            var instance = Instantiate(prefab);
            var tile = GridManager.Instance.GetRandomTile(team);
            tile.SetUnit(instance);
        }
    }

    private T GetUnit<T>(Team team, UnitType unitType) where T : BaseUnit
    {
        var unit = _units.Where(u => u.Team == team && u.UnitType == unitType).OrderBy(o => Random.value).First().UnitPrefab;
        return (T)unit;
    }

    public void SetSelectedBlueGeneral(BaseBlueG blueGeneral)
    {
        SelectedBlueGeneral = blueGeneral;
        MenuManager.instance.ShowSelectedBlueGeneral(blueGeneral); 
    }

    public void SetSelectedRedGeneral(BaseRedG redGeneral)
    {
        SelectedRedGeneral = redGeneral;
        MenuManager.instance.ShowSelectedRedGeneral(redGeneral); 
    }
}