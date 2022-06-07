using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public TeamUnits TeamUnits;
    public BaseUnit UnitPrefab;
}

public enum TeamUnits{
    // Red
    RedGeneral = 0,
    RedRifleman = 1,
    RedMinigunner = 2,
    RedSniper = 3,
    RedShotgunner = 4,
    RedScout = 5,
    RedGrenadeThrower = 6,
    RedArmoredVehicle = 7,
    // Blue
    BlueGeneral = 8,
    BlueRifleman = 9,
    BlueMinigunner = 10,
    BlueSniper = 11,
    BlueShotgunner = 12,
    BlueScout = 13,
    BlueGrenadeThrower = 14,
    BlueArmoredVehicle = 15
}
