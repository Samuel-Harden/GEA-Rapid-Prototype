using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float framesPassed;
    int Hours; //How many hours passed
    int TenMinutes; //How many times 10 minutes has passed every hour.
    int Minutes; //Minutes passed
    string timeFrame; // String to show 'am' or 'PM'.
    int timeZone; //0 for AM, 1 for PM

    public Text timeText;

	// Use this for initialization
	void Start () {
        Hours = 7;
        TenMinutes = 0;
        Minutes = 0;
        timeZone = 0;
        timeFrame = "am";
        timeText.text = "";

	}
	
    void displayTimer()
    {
        timeText.text = "Time: " + Hours.ToString() + ":" + TenMinutes.ToString() + Minutes.ToString() + timeFrame;
    }

	// Update is called once per frame
	void Update () {
        framesPassed += (Time.deltaTime);

        if(framesPassed >= 60) // NUMBER OF SECONDS PER MINUTE
        {
            Minutes++;
            if(Minutes > 9)
            {
                Minutes = 0;
                TenMinutes++;
                if(TenMinutes == 6)
                {
                    TenMinutes = 0;
                    Hours++;
                    if(Hours == 12)
                    {
                        switch(timeZone)
                        {
                            case 0:
                                timeZone = 1;
                                timeFrame = "pm";
                                break;
                            case 1:
                                timeZone = 0;
                                timeFrame = "am";
                                break;
                        }
                    }
                    if(Hours == 13)
                        Hours = 1;
                }
            }
            framesPassed = 0;
        }


        displayTimer();
	}
}
