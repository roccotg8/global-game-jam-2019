using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerdControl : MonoBehaviour
{
    
    public float characterSpeed = 5, dodgeSpeed = 25, dodgeCooldown;

    private GameObject[] objArray;
    private float vertMove, horizMove, cdTime, baseSpeed;

    private GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = characterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (characterSpeed > baseSpeed)
            characterSpeed -= 1.4f;
        else
            characterSpeed = baseSpeed;

       if(cdTime > 0)
            cdTime -= Time.deltaTime;
        

        //Debug.Log(Input.GetAxis("Horizontal"));
        //Debug.Log(Input.GetAxis("Vertical"));

        horizMove = Input.GetAxis("Horizontal") * characterSpeed;       
        vertMove = Input.GetAxis("Vertical") * characterSpeed;
        
        horizMove *= Time.deltaTime;
        vertMove *= Time.deltaTime;

        transform.Translate(horizMove, vertMove, 0);


        if (horizMove > 0) ;
        //Anim walk right
        if (horizMove < 0) ;
        //Anim walk left
        if (vertMove > Mathf.Abs(horizMove)) ;
        //Anim walk up?
        if (vertMove < -Mathf.Abs(horizMove)) ;
        //Anim walk down?



        //Interact Key/ Button
        if (Input.GetButtonDown("Interact"))
        {
            //Check area for any NPC's
            npc.ActivateQuest();
            Debug.Log("Interact");

        }

        ////Drag Item Key/Button
        //if (Input.GetButtonDown("Drag"))
        //{
        //    Debug.Log("Drag");
        //}

        //Roll or Dodge Key/Button
        if (Input.GetButtonDown("Dodge") && cdTime <= 0)
        {
            //Dodge animation play

            cdTime = dodgeCooldown;

            characterSpeed = dodgeSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "npc")
            npc = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "npc")
            npc = null;
    }
}
