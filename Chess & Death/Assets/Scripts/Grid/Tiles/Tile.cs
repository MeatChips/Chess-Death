using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public static Tile Instance;

    // SpriteRenderer - highlight of tile - checking if tile is walkable
    [SerializeField] protected SpriteRenderer sr;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject movementHighlight;

    [SerializeField] private bool isWalkable;
    public bool Walkable => isWalkable && OccupiedUnit == null;
    public bool OnMouseDownBool = true;

    public BaseUnit OccupiedUnit;

    public string tileName;

    void Awake()
    {
        Instance = this;
    }

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
        if (GameManager.Instance.GameState == GameState.BlueTurn)
        {
            BlueMovement();
        }
        else if (GameManager.Instance.GameState == GameState.RedTurn)
        {
            RedMovement();

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

    // Movement for the blue units
    public void BlueMovement()
    {
        // Unit
        BaseUnit unit = GetSelectedUnit();

        if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit == null)
            return;

        // Click on a unit and it gets selected
        else if (OccupiedUnit != null && OccupiedUnit.Teams == Team.Blue)
        {
            // If you already selected a unit and you click on another unit. Remove the highlight of the first unit
            if (SelectedUnitExists())
                SetMovementRangeVisible(GetSelectedUnit(), false);

            UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
            SetMovementRangeVisible(GetSelectedUnit(), true);
        }

        // Click on a empty tile, move your selected unit to that tile. Only able to do so inside of the movement range of the unit
        else if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit != null)
        {
            // Grab the position of the current selected unit
            Vector2 unitPosition = new Vector2(unit.transform.position.x, unit.transform.position.y);

            // Check for valid location
            if (GridManager.Instance.GetTilesInRange(unitPosition, unit.MovementRange).Contains(this))
            {
                SetMovementRangeVisible(GetSelectedUnit(), false);
                SetUnit(unit);
            }
            else
            {
                return;
            }
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.RedTurn);
        }

        // Click a tile with a enemy unit on it, destroy the enemy
        else if (UnitsManager.Instance.SelectedUnit != null && OccupiedUnit.Teams == Team.Red)
        {
            // Grab the position of the current selected unit
            Vector2 unitPosition = new Vector2(unit.transform.position.x, unit.transform.position.y);

            // Check for valid location
            if (GridManager.Instance.GetTilesInRange(unitPosition, unit.MovementRange).Contains(this))
            {
                SetMovementRangeVisible(GetSelectedUnit(), false);
                var enemy = (BaseUnit)OccupiedUnit;
                Destroy(enemy.gameObject);
                SetUnit(UnitsManager.Instance.SelectedUnit);
            }
            else
            {
                return;
            }
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

    // Movement for the blue units
    public void RedMovement()
    {
        // Unit
        BaseUnit unit = GetSelectedUnit();

        if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit == null)
            return;

        // Click on a unit and it gets selected
        else if (OccupiedUnit != null && OccupiedUnit.Teams == Team.Red)
        {
            // If you already selected a unit and you click on another unit. Remove the highlight of the first unit
            if (SelectedUnitExists())
                SetMovementRangeVisible(GetSelectedUnit(), false);

            UnitsManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
            SetMovementRangeVisible(GetSelectedUnit(), true);
        }

        // Click on a empty tile, move your selected unit to that tile. Only able to do so inside of the movement range of the unit
        else if (OccupiedUnit == null && UnitsManager.Instance.SelectedUnit != null)
        {
            // Grab the position of the current selected unit
            Vector2 unitPosition = new Vector2(unit.transform.position.x, unit.transform.position.y);

            // Check for valid location
            if (GridManager.Instance.GetTilesInRange(unitPosition, unit.MovementRange).Contains(this))
            {
                SetMovementRangeVisible(GetSelectedUnit(), false);
                SetUnit(unit);
            }
            else
            {
                return;
            }
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
        }

        // Click a tile with a enemy unit on it, destroy the enemy
        else if (UnitsManager.Instance.SelectedUnit != null && OccupiedUnit.Teams == Team.Blue)
        {
            // Grab the position of the current selected unit
            Vector2 unitPosition = new Vector2(unit.transform.position.x, unit.transform.position.y);

            // Check for valid location
            if (GridManager.Instance.GetTilesInRange(unitPosition, unit.MovementRange).Contains(this))
            {
                SetMovementRangeVisible(GetSelectedUnit(), false);
                var enemy = (BaseUnit)OccupiedUnit;
                Destroy(enemy.gameObject);
                SetUnit(UnitsManager.Instance.SelectedUnit);
            }
            else
            {
                return;
            }
            UnitsManager.Instance.SetSelectedUnit(null);
            GameManager.Instance.UpdateGameStates(GameState.BlueTurn);
        }
    }

    // Function to show or hide the tile highlights
    private void SetMovementRangeVisible(BaseUnit unit, bool state)
    {
        Vector3 currentPosition = unit.gameObject.transform.position;
        int visibleRange = unit.MovementRange;
        List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(new Vector2(currentPosition.x, currentPosition.y), visibleRange);
        tilesInRange.ForEach((tile) => { tile.movementHighlight.SetActive(state); });
    }

    // Bool for if the selected unit exists
    private bool SelectedUnitExists()
    {
        return UnitsManager.Instance.SelectedUnit == true;
    }

    // Bool for the selected unit
    private BaseUnit GetSelectedUnit()
    {
        return UnitsManager.Instance.SelectedUnit;
    }

    #region old tile highlight code
    //public void ShowMovementRange()
    //{
    //    var unit = (BaseUnit)OccupiedUnit;
    //    Vector3 myPosition = unit.gameObject.transform.position;
    //    List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(new Vector2(myPosition.x, myPosition.y), 1);
    //
    //    foreach (Tile tile in tilesInRange)
    //    {
    //        tile.movementHighlight.SetActive(true);
    //    }
    //}

    //public void HideMovementRange()
    //{
    //    var unit = (BaseUnit)OccupiedUnit;
    //    Vector3 myPosition = unit.gameObject.transform.position;
    //    List<Tile> tilesInRange = GridManager.Instance.GetTilesInRange(new Vector2(myPosition.x, myPosition.y), 10000);
    //
    //    foreach (Tile tile in tilesInRange)
    //    {
    //        tile.movementHighlight.SetActive(false);
    //    }
    //}
    #endregion

    // Set the unit on the correct position
    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}