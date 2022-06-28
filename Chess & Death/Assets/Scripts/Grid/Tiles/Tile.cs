using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    // SpriteRenderer - highlight of tile - checking if tile is walkable
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject movementHighlight;

    [SerializeField] private bool isWalkable;
    public bool Walkable => isWalkable && OccupiedUnit == null;

    public BaseUnit OccupiedUnit;

    public string tileName;

    public virtual void Init(int x, int y)
    {

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

    void OnMouseDown()
    {
        //if (GameManager.Instance.GameState != GameState.BlueTurn) return;
        if (GameManager.Instance.GameState == GameState.BlueTurn)
        {
            BlueMovement();
            ShowMovementRange();
        }
        else if (GameManager.Instance.GameState == GameState.RedTurn)
        {
            RedMovement();
            ShowMovementRange();
        }
    }

    #region old BlueMovement code
    //if (OccupiedUnit != null)
    //{
    //    if (OccupiedUnit.Teams == Team.Blue) UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
    //    else
    //    {
    //        if (UnitsManager.Instance.SelectedUnit != null)
    //        {
    //            var enemy = (BaseUnit)OccupiedUnit;
    //            Destroy(enemy.gameObject);
    //            SetUnitMove(UnitsManager.Instance.SelectedUnit);
    //            HideMovementRange();
    //            UnitsManager.Instance.SetSelectedUnit(null);
    //            GameManager.Instance.UpdateGameStates(GameState.RedTurn);
    //        }
    //    }
    //}
    //else
    //{
    //    if (UnitsManager.Instance.SelectedUnit != null)
    //    {
    //        SetUnitMove(UnitsManager.Instance.SelectedUnit);
    //        HideMovementRange();
    //        UnitsManager.Instance.SetSelectedUnit(null);
    //        GameManager.Instance.UpdateGameStates(GameState.RedTurn);
    //    }
    //}
    #endregion

    public void BlueMovement()
    {
        // Clicked an empty tile without a unit selected.
        // Do nothing.
        if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit == null)
            return;

        // Clicked an occupied friendly tile.
        // Select the unit.
        else if (OccupiedUnit != null && OccupiedUnit.Teams == Team.Blue)
        {
            UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
        }

        // Clicked an empty tile with a unit selected.
        // Move the unit to the new tile.
        else if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit != null)
        {
            SetUnit(UnitsManager.Instance.SelectedUnit);
            HideMovementRange();
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.RedTurn);
        }

        // Clicked an occupied enemy tile with a unit selected.
        // Attack the enemy unit.
        else if (UnitsManager.Instance.SelectedUnit != null && OccupiedUnit.Teams == Team.Red)
        {
            var enemy = (BaseUnit)OccupiedUnit;
            Destroy(enemy.gameObject);
            HideMovementRange();
            SetUnit(UnitsManager.Instance.SelectedUnit);
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.RedTurn);
        }
    }

    #region old RedMovement code
    //if (OccupiedUnit != null)
    //{
    //    if (OccupiedUnit.Teams == Team.Red) UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
    //    else
    //    {
    //        if (UnitsManager.Instance.SelectedUnit != null)
    //        {
    //            var enemy = (BaseUnit)OccupiedUnit;
    //            Destroy(enemy.gameObject);
    //            SetUnitMove(UnitsManager.Instance.SelectedUnit);
    //            HideMovementRange();
    //            UnitsManager.Instance.SetSelectedUnit(null);
    //            GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
    //        }
    //    }
    //}
    //else
    //{
    //    if (UnitsManager.Instance.SelectedUnit != null)
    //    {
    //        SetUnitMove(UnitsManager.Instance.SelectedUnit);
    //        HideMovementRange();
    //        UnitsManager.Instance.SetSelectedUnit(null);
    //        GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
    //    }
    //}
    #endregion

    public void RedMovement()
    {
        // Clicked an empty tile without a unit selected.
        // Do nothing.
        if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit == null)
            return;

        // Clicked an occupied friendly tile.
        // Select the unit.
        else if (OccupiedUnit != null && OccupiedUnit.Teams == Team.Red)
        {
            UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
        }

        // Clicked an empty tile with a unit selected.
        // Move the unit to the new tile.
        else if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit != null)
        {
            SetUnit(UnitsManager.Instance.SelectedUnit);
            HideMovementRange();
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
        }

        // Clicked an occupied enemy tile with a unit selected.
        // Attack the enemy unit.
        else if (UnitsManager.Instance.SelectedUnit != null && OccupiedUnit.Teams == Team.Blue)
        {
            var enemy = (BaseUnit)OccupiedUnit;
            Destroy(enemy.gameObject);
            SetUnit(UnitsManager.Instance.SelectedUnit);
            HideMovementRange();
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
        }
    }

    public void ShowMovementRange()
    {
        var unit = (BaseUnit)OccupiedUnit;
        Vector3 myPosition = unit.transform.position;
        List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(new Vector2(myPosition.x, myPosition.y), 2);

        foreach (Tile tile in tilesInRange)
        {
            tile.movementHighlight.SetActive(true);
        }
    }

    public void HideMovementRange()
    {
        var unit = (BaseUnit)OccupiedUnit;
        Vector3 myPosition = unit.transform.position;
        List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(new Vector2(myPosition.x, myPosition.y), 10000);

        foreach (Tile tile in tilesInRange)
        {
            tile.movementHighlight.SetActive(false);
        }
    }

    public void SetUnitMove(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        //List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(unit.transform.position, 5);
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
