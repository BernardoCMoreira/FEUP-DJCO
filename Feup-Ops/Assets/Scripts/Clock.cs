using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    [SerializeField] Text timeCounter;
    [SerializeField] Text scoreBoard;
    [SerializeField] Text scoreBoardScroll;

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
        if(currentTime >= 60){
            minutes = currentTime / 60;
        }
        if((Player.isFrozen && currentTime < freezeEndTime) || !(GameObject.FindGameObjectWithTag("Player")) ){
            timeCounter.color = Color.red;
        }
        else if(Player.isFrozen && (currentTime >= freezeEndTime)){
            endFreezeCount();
        }
        else{
            timeCounter.color = Color.white;
            timeCounter.text = (Mathf.Floor(currentTime/60)).ToString("00") + ":" + (currentTime%60).ToString("00");
        }
        
        scoreBoard.text =Player.score + "/10";
        scoreBoardScroll.text = Player.scroll + "/1";
    }

    public void StartFreezeCount(float freezeDuration){
        this.freezeDuration = freezeDuration;
        freezeEndTime = currentTime + freezeDuration;
    }

    private void endFreezeCount(){
        currentTime -= this.freezeDuration; 
        Player.isFrozen = false;
    }

    public string getCurrentTime(){
        return (Mathf.Floor(currentTime/60)).ToString("00") + ":" + (currentTime%60).ToString("00");
    }
    
}
