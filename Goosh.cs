using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goosh : MonoBehaviour
{
    public float radius, speed;

    public GameObject playerCharacter;

    private float distance, step, x1, x2, y1, y2;


    // Start is called before the first frame update
    void Start()
    {
        radius *= radius;   
    }

    // Update is called once per frame
    void Update()
    {


        step = Time.deltaTime * speed;
        x1 = playerCharacter.transform.position.x; x2 = this.transform.position.x;
        y1 = playerCharacter.transform.position.y; y2 = this.transform.position.y;
        
        distance = ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

        if (distance > radius)
        {
            transform.position = Vector2.Lerp(transform.position, playerCharacter.transform.position, step);
        }
        //else
            //Debug.Log("Within");

        //Debug.Log(distance);

    }
}
