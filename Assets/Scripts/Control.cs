using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Camera cam;
    public Tiles tiles;
    // Start is called before the first frame update
    void Start()
    {
        if (!cam)
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (!tiles)
            tiles = GameObject.Find("Tiles").GetComponent<Tiles>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Vector3 mouseSpot = cam.ScreenToWorldPoint(Input.mousePosition);
            if (mouseSpot.x >= 0 && mouseSpot.y >= 0) 
            {
                //Debug.Log($"X:{mouseSpot.x} Y:{mouseSpot.y}");
                Debug.Log($"X:{(int)(mouseSpot.x / .32)} Y:{(int)(mouseSpot.y / .32)}");
                int gridX = (int)(mouseSpot.x / .32);
                int gridY = (int)(mouseSpot.y / .32);

                if (gridX < tiles.plants.GetUpperBound(0) && gridY < tiles.plants.GetUpperBound(1))
                {
                    if (tiles.isOccupied(gridX, gridY))
                    {
                        if (tiles.plants[gridX, gridY].stage == tiles.plants[gridX, gridY].plant.lifeStages - 1)
                            tiles.Harvest(gridX, gridY);
                        else
                            tiles.WaterPlant(gridX, gridY);
                    }
                    else
                    {
                        tiles.PlantRandomAtPlace(gridX, gridY);
                    }
                }
                
                
            }
        }


    }


}
