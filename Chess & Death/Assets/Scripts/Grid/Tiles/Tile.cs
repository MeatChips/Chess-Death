using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Colors for tiles
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    // SpriteRenderer - highlight of tile - checking if tile is walkable
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject highlight;
    [SerializeField] private bool isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => isWalkable && OccupiedUnit == null;

    public string tileName;

    public void Init(bool isOffset)
    {
        sr.color = isOffset ? offsetColor : baseColor;
    }

    // Highligting tile you are hovering over with your mouse - Show the info of that tile
    void OnMouseEnter()
    {
        highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }


    // Movement for units (Still needs to be updated, so you can only do one move every round and for every unit movement)
    void OnMouseDown()
    {
        //if (GameManager.Instance.GameState != GameState.BlueTurn) return;
        if (GameManager.Instance.GameState == GameState.BlueTurn)
        {
            //BlueMovement();
            BlueMove();
        }
        else if (GameManager.Instance.GameState == GameState.RedTurn)
        {
            //RedMovement();
            RedMove();
        }
    }

    public void BlueMove()
    {
        if (GameManager.Instance.GameState == GameState.BlueTurn)
        {
            if (OccupiedUnit != null)
            {
                if (OccupiedUnit.Teams == Team.Blue) UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
                else
                {
                    if (UnitsManager.Instance.SelectedUnit != null)
                    {
                        var enemy = (BaseUnit)OccupiedUnit;
                        Destroy(enemy.gameObject);
                        UnitsManager.Instance.SetSelectedUnit(null);
                        GameManager.Instance.UpdateGameStates(GameState.RedTurn);
                    }
                }
            }
            else
            {
                if (UnitsManager.Instance.SelectedUnit != null)
                {
                    SetUnit(UnitsManager.Instance.SelectedUnit);
                    UnitsManager.Instance.SetSelectedUnit(null);
                    GameManager.Instance.UpdateGameStates(GameState.RedTurn);
                }
            }
        }
    }

    public void RedMove()
    {
        if (GameManager.Instance.GameState == GameState.RedTurn)
        {
            if (OccupiedUnit != null)
            {
                if (OccupiedUnit.Teams == Team.Red) UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
                else
                {
                    if (UnitsManager.Instance.SelectedUnit != null)
                    {
                        var enemy = (BaseUnit)OccupiedUnit;
                        Destroy(enemy.gameObject);
                        UnitsManager.Instance.SetSelectedUnit(null);
                        GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
                    }
                }
            }
            else
            {
                if (UnitsManager.Instance.SelectedUnit != null)
                {
                    SetUnit(UnitsManager.Instance.SelectedUnit);
                    UnitsManager.Instance.SetSelectedUnit(null);
                    GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
                }
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


    //if (IsEnemy()) // This is a private method to return a boolean check below
    //{
    //    switch (OccupiedUnit.UnitType)
    //    {
    //        // Here you'll switch through each unit type if you need to and choose what to do based on that
    //        case UnitType.General:
    //            // log for unit
    //            break;
    //        case UnitType.Rifleman:
    //            // log for unit
    //            break;
    //        case UnitType.Minigunner:
    //            // log for unit
    //            break;
    //        case UnitType.Sniper:
    //            // log for unit
    //            break;
    //        case UnitType.Shotgunner:
    //            // log for unit
    //            break;
    //        case UnitType.Scout:
    //            // log for unit
    //            break;
    //        case UnitType.GrenadeThrower:
    //            // log for unit
    //            break;
    //        case UnitType.ArmoredVehicle:
    //            // log for unit
    //            break;
    //    }
    //}
    //else
    //{
    //    if (UnitsManager.Instance.SelectedBlueGeneral != null)
    //    {
    //        SetUnit(UnitsManager.Instance.SelectedBlueGeneral);
    //        UnitsManager.Instance.SetSelectedBlueGeneral(null);
    //        GameManager.Instance.UpdateGameStates(GameState.RedTurn);
    //    }
    //}
    //
    //// Little private methods like this condense your boolean checks down into more easily
    //// digestible operations like you see above in the OnMouseDown method.
    //bool IsEnemy(UnitType unitType)
    //{
    //    return (unitType != null && unitType. == Team.Red);
    //}ss
}
