using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGeneration : MonoBehaviour
{

    [SerializeField]
    int width, height;

    [SerializeField]
    public GameObject[] groundTiles;

    [SerializeField]
    public int offset;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                int tile = Random.Range(0, groundTiles.Length);
                Vector2 pos = new Vector2(x*offset, y*offset);
                Instantiate(groundTiles[tile], pos, Quaternion.identity);
            }
        }
    }
}
