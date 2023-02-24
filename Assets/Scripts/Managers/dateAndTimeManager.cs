using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dateAndTimeManager : MonoBehaviour
{
    float secondsBetweenMinuets = 1f;
    float timeSinceLastMinuetSwitch;

    public static int currentMinute = 0;
    public static int currentHour = 0;

    public static int currentDay = 1;
    public static int currentMonth = 1;
    public static int currentYear = 1;

    public static int[] daysInMonths = 
        {
        31,
        28,
        31,
        30,
        31,
        30,
        31,
        31,
        30,
        31,
        30,
        31,
        };

    public static bool timeIsPaused = false;
    void Update()
    {
        if (!timeIsPaused) 
        {
            timeSinceLastMinuetSwitch += Time.deltaTime;
            if (timeSinceLastMinuetSwitch > secondsBetweenMinuets)
            {
                timeSinceLastMinuetSwitch -= secondsBetweenMinuets;
                currentMinute++;
                if (currentMinute >= 60)
                {
                    currentMinute = 0;
                    currentHour++;
                    if (currentHour >= 24) newDay();
                }
            }
        }
    }
    public void newDay()
    {
        currentMinute = 0;
        currentHour = 6;
        if (daysInMonths[currentMonth - 1] > currentDay)
        {
            currentDay++;
        }
        else if (currentMonth < 12)
        {
            currentMonth++;
            currentDay = 1;
        }
        else
        {
            currentMonth = 1;
            currentDay = 1;
            currentYear++;
        }

    }
    
}
