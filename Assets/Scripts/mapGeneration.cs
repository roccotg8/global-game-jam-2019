using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGeneration : MonoBehaviour
{
    [SerializeField]
    int mapMin, mapMax, minGroundPasses, maxGroundPasses, groundObjectPercentChance, spawnPercentChance, roomChance, npcChance;

    [SerializeField]
    float terrainOffset;

    [SerializeField]
    GameObject[] terrainTiles, groundObjects, hubTiles, spawnTile, secretRoom, npcList;

    [SerializeField]
    int width, height;

    public GameObject[] terrain, groundClutter, spawnLocations, hiddenRoom, npcs, hub;

    private void Awake()
    {
        width = Random.Range(mapMin, mapMax);
        height = Random.Range(mapMin, mapMax);

        GenerateTerrain();
        EditMapBounds();
        GenerateGroundObjects();
        GenerateSpawnTiles();
        GenerateSecretRoom();
        PlaceHub();
        PlaceNPC();
    }

    void GenerateTerrain()
    {
        //create the base terrain
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int tile = Random.Range(0, terrainTiles.Length);
                Vector2 pos = new Vector2(x * terrainOffset, y * terrainOffset);
                Instantiate(terrainTiles[tile], pos, Quaternion.identity);
            }
        }
        terrain = GameObject.FindGameObjectsWithTag("ground");
    }

    void GenerateGroundObjects()
    {
        //generate the random stuff on the ground
        int groundPasses = Random.Range(minGroundPasses, maxGroundPasses);
        for(int i = 0; i < groundPasses; i++)   //do each ground pass
        {
            randomInTilePlacement(groundObjects, groundObjectPercentChance);           
        }
        groundClutter = GameObject.FindGameObjectsWithTag("clutter");
    }

    void GenerateSpawnTiles()
    {
        //generate spawn locations
        randomInTilePlacement(spawnTile, spawnPercentChance, true);
        spawnLocations = GameObject.FindGameObjectsWithTag("spawn");
    }

    void GenerateSecretRoom()
    {
        //generate secret room
        randomInTilePlacement(secretRoom, roomChance, false, true);
        hiddenRoom = GameObject.FindGameObjectsWithTag("secretRoom");
    }

    void PlaceHub()
    {
        //place the hub in the center of the map
        int tile = Random.Range(0, hubTiles.Length);
        Vector2 hubPos = new Vector2(((width / 2.0f) * terrainOffset) - (terrainOffset / 2.0f), ((height / 2.0f) * terrainOffset) - (terrainOffset / 2.0f));
        Instantiate(hubTiles[tile], hubPos, Quaternion.identity);
        hub = GameObject.FindGameObjectsWithTag("hub");
    }

    void PlaceNPC()
    {
        //place npcs in the world
        randomInTilePlacement(npcList, npcChance, true, false);
        npcs = GameObject.FindGameObjectsWithTag("npc");
    }

    void EditMapBounds()
    {
        
    }

    public void randomInTilePlacement(GameObject[] objects, int percentChance, bool guaranteeOne = false, bool onlyOne = false)
    {
        bool oneExists = false;
        for (int x = 0; x < width; x++) //iterate through x values of the map
        {
            for (int y = 0; y < height; y++)    //iterate through y values of the map
            {
                if (Random.Range(1, 100) <= percentChance)   //% chance of having the object spawn per tile
                {
                    int tile = Random.Range(0, objects.Length);    //randomly select the object to place

                    float inTileOffsetX = ((Random.Range(-500, 500) / 1000.0f) * terrainOffset);  //randomly chooses x offset
                    float inTileOffsetY = ((Random.Range(-500, 500) / 1000.0f) * terrainOffset);  //randomly chooses y offset

                    Vector2 pos = new Vector2((x * terrainOffset) + inTileOffsetX, (y * terrainOffset) + inTileOffsetY);  //sets position of  object

                    Instantiate(objects[tile], pos, Quaternion.identity);

                    oneExists = true;

                    if(onlyOne)
                    {
                        return;
                    }
                }
            }
        }

        if(!oneExists && guaranteeOne)
        {
            GuaranteeOne(objects);
        }
    }

    public void GuaranteeOne(GameObject[] objects)
    {
        //choose a random tile
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);

        //choose a Random place in the tile
        float inTileOffsetX = ((Random.Range(-500, 500) / 1000.0f) * terrainOffset);
        float inTileOffsetY = ((Random.Range(-500, 500) / 1000.0f) * terrainOffset);

        Vector2 pos = new Vector2((x * terrainOffset) + inTileOffsetX, (y * terrainOffset) + inTileOffsetY);  //sets position

        int tile = Random.Range(0, objects.Length);

        Instantiate(objects[tile], pos, Quaternion.identity);
    }
}
