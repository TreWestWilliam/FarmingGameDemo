using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{
    public PlantManager pm;
    public PlantInstance[,] plants;
    public Tilemap tm;

    public Text daysText;
    public int dayCount = 0;

    public GameObject rainObject;

    // Start is called before the first frame update
    void Start()
    {
        plants = new PlantInstance[15, 12];
        
    }

    public bool isOccupied(int x, int y) 
    {
        if (plants[x, y] != null)
            return true;
        return false;
    }

    public void PlantSomething(Plant p,int x, int y) 
    {
        plants[x, y] = new PlantInstance(p);
        tm.SetTile(new Vector3Int(x, y, 0), plants[x, y].texture);

    }

    public void PlantRandomAtPlace(int x, int y) 
    {
        PlantSomething(pm.randomPlant(), x, y);
    }

    public void PopulateRandom() 
    {
        for (int x = 0; x < plants.GetUpperBound(0); x++)
        {
            for (int y = 0; y < plants.GetUpperBound(1); y++)
            {
                PlantRandomAtPlace(x, y);
            }
        }
    }

    public void ProgressDay()
    {
        for (int x = 0; x < plants.GetUpperBound(0); x++)
        {
            for (int y = 0; y < plants.GetUpperBound(1); y++)
            {
                if (plants[x, y] != null)
                {
                    plants[x, y].Age();
                    tm.SetTile(new Vector3Int(x, y, 0), plants[x, y].texture);
                }
            }
        }

        if (Random.Range(0, 2) == 1)
        {
            Rain();
            rainObject.SetActive(true);
        }
        else 
        {
            rainObject.SetActive(false);
        }

        dayCount++;
        daysText.text = $"Days: {dayCount}";

    }

    public void Harvest(int x, int y) 
    {
        plants[x, y] = null;
        tm.SetTile(new Vector3Int(x, y, 0), null) ;
    }

    public void Rain() 
    {
        Debug.Log("Raining");
        foreach (PlantInstance p in plants) 
        {
            if (p != null)
                p.isWatered = true;
        }
    }

    public void WaterPlant(int x, int y)
    {
        if (x >=0 && x < plants.GetUpperBound(0) && y >= 0 && y < plants.GetUpperBound(1)) 
        {
            if (plants[x, y] != null)
            {
                Debug.Log($"Watering {plants[x, y].plant.plantName} at {x},{y}");
                plants[x, y].isWatered = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
