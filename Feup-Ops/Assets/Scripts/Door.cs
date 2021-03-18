using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Text Message;
    [SerializeField] Player player;
    [SerializeField] Boss boss;

    void OnTriggerStay2D(Collider2D col){
        if (col.CompareTag("Player") && boss){
            Message.text = ("This door is locked...");
        }

        if(gameObject.name == "Door"  && !boss){
            if(col.CompareTag("Player")){
                Message.text = ("PRESS [O] TO OPEN");
            }

            if(Input.GetKeyDown(KeyCode.O) && player.transform.position.y < -10f){
                player.exitSecretLevel();
            }
            else if(Input.GetKeyDown(KeyCode.O) && player.transform.position.y >= -10f){
                player.enterSecretLevel();
            }
        }
        else if(gameObject.name == "LeaveDoor"){
            if(col.CompareTag("Player")){
                Message.text = ("PRESS [E] TO OPEN");
        
                if(Input.GetKeyDown(KeyCode.E)){
                    GameController gameController = player.GetComponent<GameController>();
                    if(gameController)
                        gameController.endGame();
                }
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        if (col.CompareTag("Player")){
            Message.text = ("");
        }
    }
}
