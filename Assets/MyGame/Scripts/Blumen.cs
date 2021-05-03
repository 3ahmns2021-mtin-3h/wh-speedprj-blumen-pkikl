using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blumen : MonoBehaviour
{
    private int spacePress;
    private int kPress;

    public float startTime, stopTime, timer;
    bool isTimerRunning;


    // Start is called before the first frame update
    void Start()
    {
        spacePress = 0;
        kPress = 0;
        isTimerRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = stopTime + (Time.time - startTime);
        Debug.Log("Overall " + timer);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("hello spacy" + spacePress);
            spacePress++;
        }
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            TimerStart();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Debug.Log("hello k" + kPress);
            kPress++;
        }
    }
    void TimerStart()
    {
        if(isTimerRunning)
        {
            startTime = Time.time;
        }
        
    }
    void TimerStop()
    {
        if(isTimerRunning)
        {
            stopTime = Time.time;
        }

    }
    void TimerReset()
    {
        timer = startTime = stopTime = 0.0f;
    }
}
