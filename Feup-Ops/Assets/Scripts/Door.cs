using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Text Message;
    private bool secretLevel;

    void Start(){
        secretLevel = false;
    }
    void OnTriggerEnter2D(Collider2D col){
        
        if(col.CompareTag("Player")){
            Message.text = ("[O] to Open the door! ");
              if(Input.GetKeyDown("o")){
                Debug.Log("Door opened");
            }
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if (col.CompareTag("Player")){
            if(Input.GetKeyDown("o")){
                Debug.Log("Door opened");
            }
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.CompareTag("Player")){
            Message.text = ("");
        }
    }
}
