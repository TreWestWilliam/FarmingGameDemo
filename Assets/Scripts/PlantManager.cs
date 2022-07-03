using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantManager : MonoBehaviour
{
    public Tile[] strawberrySprites;
    public Plant strawberry;

    public Tile[] springOnionSprites;
    public Plant springOnion;

    public Plant cabbage;
    public Tile[] cabbageSprites;

    public Tile[] cauliflourSprites;
    public Plant cauliflour;

    public List<Plant> plants = new List<Plant>();

    // Start is called before the first frame update
    void Awake()
    {
        strawberry = new Plant("Strawberry", strawberrySprites);
        springOnion = new Plant("Spring Onion",2, springOnionSprites);
        cabbage = new Plant("Cabbage", cabbageSprites);
        cauliflour = new Plant("Califlour", 2, cauliflourSprites);
        plants.Add(strawberry);
        plants.Add(springOnion);
        plants.Add(cabbage);
        plants.Add(cauliflour);
    }

    public Plant randomPlant() 
    {
        int choice = 0;
        choice = Random.Range(0, plants.Count);
        return plants[choice];
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
