using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Text Message;
    public Player player;
    //public Boss boss;
    private bool collision;

    void Start(){
        Debug.Log("STARTED");
        collision = false;
    }
    void OnTriggerEnter2D(Collider2D col){
        collision = true;
        if (col.CompareTag("Player")){
            Message.text = ("[O] to Open the door! ");
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

            if(Input.GetKeyDown(KeyCode.O) && player.transform.position.y < -10f){
                player.exitSecretLevel();
            }

            else if(Input.GetKeyDown(KeyCode.O)  && player.transform.position.y >= -10f){
                player.enterSecretLevel();
            }
        }
    }
}
