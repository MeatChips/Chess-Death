using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandTile : Tile
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;

    public override void Init(int x, int y)
    {
        var isOffset = x % 2 != y % 2;
        sr.color = isOffset ? offsetColor : baseColor;
    }
}
