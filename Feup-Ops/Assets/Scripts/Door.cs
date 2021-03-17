using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Text Message;
    [SerializeField] Player player;
    [SerializeField] Boss boss;
    bool collision;

    void Start(){
        collision = false;
    }

    void OnTriggerStay2D(Collider2D col){
        collision = true;
        if (col.CompareTag("Player") && boss){
            Message.text = ("This door is locked...");
        }
        else if(col.CompareTag("Player") && !boss){
            Message.text = ("PRESS [O] TO OPEN");
        }
    }
    
    void OnTriggerExit2D(Collider2D col){
        collision = false;
        if (col.CompareTag("Player")){
            Message.text = ("");
        }
    }

    void Update(){
        if(boss) return;

        if(collision){
            if(gameObject.name == "Door"){
                if(Input.GetKeyDown(KeyCode.O) && player.transform.position.y < -10f){
                    player.exitSecretLevel();
                }
                else if(Input.GetKeyDown(KeyCode.O) && player.transform.position.y >= -10f){
                    player.enterSecretLevel();
                }
            }
            else if(gameObject.name == "LeaveDoor"){
                if(Input.GetKeyDown(KeyCode.O)){
                    GameController gameController = player.GetComponent<GameController>();
                    if(gameController)
                        gameController.endGame();
                }
            }
        }
    }
}
