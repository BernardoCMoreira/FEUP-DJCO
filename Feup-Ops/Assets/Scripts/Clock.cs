using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    [SerializeField] Text timeCounter;
    [SerializeField] Text scoreBoard;

    private float day;
    float currentTime = 0f;
    float startingTime = 0f;
    float minutes = 0f;
    float freezeEndTime = 0f;
    float freezeDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1  * Time.deltaTime;
        if(currentTime == 60){
            minutes ++ ;
            currentTime = 0;
        }
        if(Player.isFrozen && currentTime < freezeEndTime){
            timeCounter.color = Color.red;
        }
        else if(Player.isFrozen && (currentTime >= freezeEndTime)){
            endFreezeCount();
        }
        else{
            timeCounter.color = Color.white;
            timeCounter.text = minutes.ToString("00") + ":" + currentTime.ToString("00");
        }

        scoreBoard.text = "Score: " + Player.score;

    }

    public void StartFreezeCount(float freezeDuration){
        this.freezeDuration = freezeDuration;
        freezeEndTime = currentTime + freezeDuration;
    }
    private void endFreezeCount(){
        currentTime -= this.freezeDuration; 
        Player.isFrozen = false;
    }
    
}
