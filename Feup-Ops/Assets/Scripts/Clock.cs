using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public Text timeCounter;
    private float day;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / 60f;
        float dayNormalized = day % 1f;


        float hours = Mathf.Floor(dayNormalized * 24f);
        float minutesPerHour = 60f;
        string minutes = (((dayNormalized * hours) % 1f) * minutesPerHour).ToString("00");
    
        timeCounter.text = hours.ToString("00") + ":" + minutes;
    
    }
}
