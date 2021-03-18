using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text Message;
    [SerializeField] Player player; //script
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] GameOverScreen winScreen;
    [SerializeField] GameOverScreen winScreenMIT;
    [SerializeField] AudioSource audioSource;

    public void endGame(){       
        audioSource.Stop();
        
        removeComponents();

        if(player.getScore() < 10){
            DisplayMenu(1); //Lost
        }
        else if (player.getScore() == 10 && !player.hasScroll() ){
            DisplayMenu(2); //Win
        }
        else if (player.getScore() == 10 && player.hasScroll() ){
            DisplayMenu(3); //Win MIT
        }

        player.DestroyPlayer();
    }

    private void removeComponents(){
        if(GameObject.FindGameObjectWithTag("CanvasTime")) GameObject.FindGameObjectWithTag("CanvasTime").SetActive(false);
        if(GameObject.Find("BookBar")) GameObject.Find("BookBar").SetActive(false);
        if(GameObject.Find("ImageScroll")) GameObject.Find("ImageScroll").SetActive(false);
        if(GameObject.Find("ImageScroll_Inactive")) GameObject.Find("ImageScroll_Inactive").SetActive(false);
    }

    
    public void DisplayMenu(int screenType){
        string time = "00:00";
        GameObject c = GameObject.FindGameObjectWithTag("Clock");
        if(c!=null){
            time = c.GetComponent<Clock>().getCurrentTime();
        }
        string scroll="";
        if(player.hasScroll()) 
            scroll+="YES";
        else 
            scroll += "NO";

        switch(screenType){
            case 1:
                gameOverScreen.Setup(player.getScore(), time, scroll);
            break;
            case 2:
                winScreen.Setup(player.getScore(), time, scroll);
            break;
            case 3:
                winScreenMIT.Setup(player.getScore(), time, scroll);
            break;
        }
    }
}
