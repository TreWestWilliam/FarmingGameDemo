using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantInstance
{
    public int days;
    public int stage;
    public float health;
    public bool isWatered;
    public Plant plant;
    public Tile texture;

    public void Age() 
    {
        if (isWatered)
        {
            days++;
            health += 1;
            stage = (int)(((float)plant.lifeStages / (float)plant.lifeLength) * days);
            if (stage >= plant.lifeStages)
                stage = plant.lifeStages - 1;
            isWatered = false;

            //Debug.Log($"Growing {plant.plantName}");

            texture = plant.stageTextures[stage];
        }
        else 
        {
            health -= 1;
            //Todo plant death
        }

        //Debug.Log($"{plant.plantName}:{days},{stage}");
    }

    public PlantInstance(Plant p)
    {
        days = 0;
        stage = 0;
        health = 1;
        isWatered = false;
        plant = p;
        texture = p.stageTextures[0];
    }

}
