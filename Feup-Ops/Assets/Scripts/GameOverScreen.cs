using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{   

    public Text pointsText;
    public Text timeText;

    public void Setup(int score, string time){
        gameObject.SetActive(true);
        pointsText.text="SCORE : " + score.ToString();
        timeText.text = "TIME : " + time;
    }

    public void ExitGame(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
