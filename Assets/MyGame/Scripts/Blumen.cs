using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blumen : MonoBehaviour
{
    private int spacePress;
    private int kPress;
    private bool isSpacePressed;
    private bool isTimerRunning;
    private bool isKPressed;

    public float startTime, stopTime, timer;
    public GameObject prefabBlume;
    public GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        spacePress = 0;
        kPress = 0;
        isTimerRunning = false;
        isSpacePressed = false;
        isKPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = stopTime + (Time.time - startTime);
        //Debug.Log("Overall " + timer);

        int seconds = (int)timer % 60;

        if (isTimerRunning)
        {
            if(isSpacePressed && seconds >= 1)
            {
          
                isSpacePressed = false;
                TimerStop();
                TimerReset();
                CreateBlumen(spacePress);
            }
            if(isKPressed && seconds >= 1)
            {
                isKPressed = false;
                TimerStop();
                TimerReset();
            }
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("hello spacy" + spacePress);
            spacePress++;
            isSpacePressed = true;
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
        if(isTimerRunning == false)
        {
            startTime = Time.time;
            isTimerRunning = true;
        }
        
    }
    void TimerStop()
    {
        if(isTimerRunning)
        {
            stopTime = Time.time;
            isTimerRunning = false;
        }

    }
    void TimerReset()
    {
        timer = startTime = stopTime = 0.0f;
        //Debug.Log("TimerReset");
    }

    public void CreateBlumen(int numberBlumen)
    {
        Debug.Log("create Blumen");

        for (int i = 0; i < numberBlumen; i++)
        {

            Instantiate(prefabBlume, new Vector2(i * 2.0f, 0),Quaternion.identity, parentObj.transform);
        }
    }
}
