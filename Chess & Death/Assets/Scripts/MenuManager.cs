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
    [SerializeField] private GameObject _TeamRedWonObject;
    [SerializeField] private GameObject _TeamBlueWonObject;
    [SerializeField] private GameObject _GameInfoObject;
    

    [Header("Buttons")]
    public Button GameInfoButton;
    public Button GameInfoExitButton;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Button GameInfoBtn = GameInfoButton.GetComponent<Button>();
        GameInfoBtn.onClick.AddListener(GamePause);

        Button GameInfoExitBtn = GameInfoExitButton.GetComponent<Button>();
        GameInfoExitBtn.onClick.AddListener(GameResume);
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

    public void ShowSelectedUnit(BaseUnit unit)
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

    public void GamePause()
    {
        Time.timeScale = 0f;
    }

    public void GameResume()
    {
        Time.timeScale = 100f;
    }

    public void TeamRedWon()
    {
        _TeamRedWonObject.SetActive(true);
        _GameInfoObject.SetActive(false);
    }

    public void TeamBlueWon()
    {
        _TeamBlueWonObject.SetActive(true);
        _GameInfoObject.SetActive(false);
    }
}