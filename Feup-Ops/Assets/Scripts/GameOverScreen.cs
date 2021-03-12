using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{   

    public Text pointsText;

    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text="SCORE : " + score.ToString();
    }

    public void ExitGame(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
