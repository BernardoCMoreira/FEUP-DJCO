using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleDoors : MonoBehaviour
{
    [SerializeField] Text Message;
    public Player player;
    private bool collision;
    public GameOverScreen gameOverScreen;
    public GameOverScreen winScreen;
    public GameOverScreen winScreenMIT;
    public AudioSource audioSource;

    void Start(){
        collision = false;
    }
    void OnTriggerStay2D(Collider2D col){
        collision = true;
        if(col.CompareTag("Player")){
            Message.text = ("PRESS [O] TO END GAME");
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        collision = false;
        if (col.CompareTag("Player")){
            Message.text = ("");
        }
    }

    void Update(){
        if(collision){
            if(Input.GetKeyDown(KeyCode.O)){
               endGame();
            }
        }
    }

    void endGame(){
        
        audioSource.Stop();

        GameObject obj = GameObject.FindGameObjectWithTag("CanvasTime");
        obj.SetActive(false);

        if(Player.score < 10){
            gameLost();
        }
        else if (Player.score == 10 && Player.scroll == 0){
            gameWon();
        }
         else if (Player.score == 10 && Player.scroll == 1){
            gameWonMIT();
        }
    }

    void gameLost(){
        string time = "00:00";
        GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                time = c.GetComponent<Clock>().getCurrentTime();
            }
        gameOverScreen.Setup(Player.score, time);
    }

    void gameWon(){
        string time = "00:00";
        GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                time = c.GetComponent<Clock>().getCurrentTime();
            }
        winScreen.Setup(Player.score, time);
    }
     void gameWonMIT(){
        string time = "00:00";
        GameObject c = GameObject.FindGameObjectWithTag("Clock");
            if(c!=null){
                Debug.Log(GetComponent<Clock>());
                time = c.GetComponent<Clock>().getCurrentTime();
            }
        winScreenMIT.Setup(Player.score, time);
    }
}
