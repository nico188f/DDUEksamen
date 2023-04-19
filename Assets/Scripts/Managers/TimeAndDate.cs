using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using TMPro;


public class TimeAndDate : MonoBehaviour
{
    public Light2D Light;
    float currentTime;
    int day = 1;
    public Color nightColor;
    public Color dayColor;
    public float wholeDay = 1;
    public TextMeshProUGUI DateText;

    void Start()
    {
        currentTime = wholeDay * 60;
    }
    

private void Update()
    {
        currentTime -= Time.deltaTime;
//        Debug.Log(nightColor);
      //  Debug.Log(dayColor);
     //   Debug.Log(Time.time);
       // Debug.Log(wholeDay);
      //  Debug.Log(Light.color);
        Light.color = Color.Lerp(dayColor, nightColor, Mathf.PingPong(Time.time / (wholeDay* 30), 1));
    if (currentTime< 0)
        {
            currentTime = wholeDay* 60;
            day++;
            DateText.text = "Day: " + day;
        }
    }
}
