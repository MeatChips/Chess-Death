using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;

    public BaseUnit OccupiedUnit;
    public bool walkable => isWalkable && OccupiedUnit == null;

    public string tileName;

    public void Init(bool isOffset)
    {
        sr.color = isOffset ? offsetColor : baseColor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }

    void OnMouseDown()
    {
        if (GameManager.Instance.GameState != GameState.BlueTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Teams == Team.Blue) UnitsManager.Instance.SetSelectedBlueGeneral((BaseBlueG)OccupiedUnit);
            else
            {
                if (UnitsManager.Instance.SelectedBlueGeneral != null)
                {
                    var enemy = (BaseRedG)OccupiedUnit;
                    Destroy(enemy.gameObject);
                    UnitsManager.Instance.SetSelectedBlueGeneral(null);
                }
            }
        }
        else
        {
            if (UnitsManager.Instance.SelectedBlueGeneral != null)
            {
                SetUnit(UnitsManager.Instance.SelectedBlueGeneral);
                UnitsManager.Instance.SetSelectedBlueGeneral(null);
            }
        }
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    //if (IsEnemy(OccupiedUnit))
    //{
    //    switch (OccupiedUnit.UnitType)
    //    {
    //                case UnitType.BlueGeneral:
    //                    // logics for Blue General here
    //                    break;
    //                case UnitType.BlueRifleman:
    //                    // logics for Blue Rifleman here
    //                    break;
    //                case UnitType.BlueMinigunner:
    //                    // logics for Blue Minigunner here
    //                    break;
    //                case UnitType.BlueSniper:
    //                    // logics for Blue Sniper here
    //                    break;
    //                case UnitType.BlueShotgunner:
    //                    // logics for Blue Shotgunner here
    //                    break;
    //                case UnitType.BlueScout:
    //                    // logics for Blue Scout here
    //                    break;
    //                case UnitType.BlueGrenadeThrower:
    //                    // logics for Blue Grenade Thrower here
    //                    break;
    //                case UnitType.BlueArmoredVehicle:
    //                    // logics for Blue Armored Vehicle here
    //                    break;
    //    }
    //}

    //private bool IsEnemy(UnitType<BlueG>)
    //{
    //    return (unitToCheck != null && OccupiedUnit.Teams == Teams.Blue);
    //}
}
