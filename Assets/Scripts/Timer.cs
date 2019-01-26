using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float count = 300f;
    public Text clock;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;


        string minutes = ((int)count / 60).ToString();
        string seconds = (count % 60).ToString("f2");

        clock.text = minutes + ":" + seconds;
    }
}
