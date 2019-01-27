using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goosh : MonoBehaviour
{
    public float radius, speed;

    public GameObject playerCharacter;

    private GameObject item; 

    private Animator alert;

    private float distance, step, x1, x2, y1, y2;


    // Start is called before the first frame update
    void Start()
    {
        radius *= radius;

        alert = transform.GetChild(0).transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // npcItem


        //item = GameObject.FindWithTag("npcItem");

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger Enter");
        if (collider.gameObject.tag == "clutter")
            return;
        else if (collider.gameObject.tag == "npcItem")
        {
            alert.Play("ItemNear", 0 , 0);
        }
        else
        {
            alert.Play("MonsterNear", 0, 0);
        }
    }
}


