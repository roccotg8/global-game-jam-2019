using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGeneration : MonoBehaviour
{

    [SerializeField]
    int width, height, minGroundPasses, maxGroundPasses, groundObjectPercentChance;

    [SerializeField]
    float terrainOffset;

    [SerializeField]
    GameObject[] terrainTiles, groundObjects;

    [SerializeField]
    GameObject hubTile;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        //create the base terrain
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                int tile = Random.Range(0, terrainTiles.Length);
                Vector2 pos = new Vector2(x*terrainOffset, y*terrainOffset);
                Instantiate(terrainTiles[tile], pos, Quaternion.identity);
            }
        }

        //generate the random stuff on the ground
        int groundPasses = Random.Range(minGroundPasses, maxGroundPasses);
        for(int i = 0; i < groundPasses; i++)   //do each ground pass
        {
            for (int x = 0; x < width; x++) //iterate through x values of the map
            {
                for (int y = 0; y < height; y++)    //iterate through y values of the map
                {
                    if (Random.Range(1,100) >= groundObjectPercentChance)   //50% chance of having ground stuff
                    {
                        int tile = Random.Range(0, groundObjects.Length);    //randomly select the ground stuff tile

                        float inTileOffsetX = ((Random.Range(-500,500)/1000.0f) * terrainOffset);  //randomly chooses x offset
                        float inTileOffsetY = ((Random.Range(-500,500)/1000.0f) * terrainOffset);  //randomly chooses y offset

                        Vector2 pos = new Vector2((x*terrainOffset)+inTileOffsetX, (y*terrainOffset)+inTileOffsetY);  //sets position of ground object
                        
                        Instantiate(groundObjects[tile], pos, Quaternion.identity);
                    }
                }
            }           
        }

        //place the hub in the center of the map
        Vector2 hubPos = new Vector2(((width/2.0f)*terrainOffset)-(terrainOffset/2.0f), ((height/2.0f)*terrainOffset)-(terrainOffset/2.0f));
        Instantiate(hubTile, hubPos, Quaternion.identity);
    }
}
