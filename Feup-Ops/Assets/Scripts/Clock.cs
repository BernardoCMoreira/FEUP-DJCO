﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    [SerializeField] Text timeCounter;
    private float day;
    float currentTime = 0f;
    float startingTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1  * Time.deltaTime;
        timeCounter.text = currentTime.ToString("0");
    
    }
}
