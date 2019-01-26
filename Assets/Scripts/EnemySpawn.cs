using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // script periodicaly spawns an enemy entity relative to player location and based on time passed 
    // and if the player is colliding with a particular game object

    public GameObject enemy;  //enemy prefab
    bool spawn = false;  // dont spawn on default
    GameObject player;  // player 
    public Timer time;  // time count
    float speed; // how fast the enemy moves
    float spawnTime = 2f; //time til spawn 
    Vector2 spawnPos; 


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");  //tracks the player object
        spawnPos = player.transform.position; 
        speed = 5f;
        spawnTime = 2f; 
    }

    // Update is called once per frame
    void Update()
    {
        Hunt(); 
    }

    void Spawn ()
    {
        Instantiate(enemy );
    }

    void Hunt()
    {
        //lerp the enemy towards the player 
        
    }
}

