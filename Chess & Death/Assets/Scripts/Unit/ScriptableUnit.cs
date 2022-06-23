using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Team Team;
    public UnitType UnitType;

    public BaseUnit UnitPrefab;
}

// All teams
public enum Team
{
    Red = 0,
    Blue = 1
}

// All unit types
public enum UnitType
{
    General,
    Rifleman,
    Minigunner,
    Sniper,
    Shotgunner,
    Scout,
    GrenadeThrower,
    ArmoredVehicle
}