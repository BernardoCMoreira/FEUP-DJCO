using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{   
    [SerializeField] Text pointsText;
    [SerializeField] Text scrollText;
    [SerializeField] Text timeText;

    public void Setup(int score, string time, string scroll){
        gameObject.SetActive(true);
        pointsText.text="SCORE : " + score.ToString();
        timeText.text = "TIME : " + time;
        scrollText.text = "SCROLL : " + scroll;
    }

    public void ExitGame(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
