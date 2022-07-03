using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant
{
    public string plantName;
    public int lifeLength;
    public int lifeStages;
    public Tile [] stageTextures;

    public Plant() 
    {
        plantName = "Misc Plant";
        lifeLength = 4;
        lifeStages = 4;
        stageTextures = new Tile[4];
    }
    public Plant(Tile[] s) 
    {
        plantName = "Misc Plant";
        lifeLength = s.Length;
        lifeStages = s.Length;
        stageTextures = s;
    }
    public Plant(string n,Tile[] s)
    {
        plantName = n;
        lifeLength = s.Length;
        lifeStages = s.Length;
        stageTextures = s;
    }
    public Plant(string n, int m, Tile[] s)
    {
        plantName = n;
        lifeLength = s.Length * m;
        lifeStages = s.Length;
        stageTextures = s;
    }
}
