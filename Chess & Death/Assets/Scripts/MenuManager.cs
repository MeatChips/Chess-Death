using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _SelectedUnitObject;
    [SerializeField] private GameObject _TileInfoObject;
    [SerializeField] private GameObject _TileUnitObject;

    void Awake()
    {
        Instance = this;
    }

    // Show the info of the tiles. What kind of tile it is and if there is unit on it
    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _TileInfoObject.SetActive(false);
            _TileUnitObject.SetActive(false);
            return;
        }

        _TileInfoObject.GetComponentInChildren<Text>().text = tile.tileName;
        _TileInfoObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            _TileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _TileUnitObject.SetActive(true);
        }
    }

    // Show what unit you have selected (Still needs to be updated, everything into 1 or 2 functions)

    public void ShowSelectedUnit (BaseUnit unit)
    {
        if (unit == null)
        {
            _SelectedUnitObject.SetActive(false);
            return;
        }

        Debug.Log(unit.UnitName);
        _SelectedUnitObject.GetComponentInChildren<Text>().text = unit.UnitName;
        _SelectedUnitObject.SetActive(true);
    }
}
