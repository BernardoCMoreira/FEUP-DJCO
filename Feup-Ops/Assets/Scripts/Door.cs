using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Text Message;
    public Player player;

    void OnTriggerEnter2D(Collider2D col){
        if(!col.CompareTag("Player")) return;
        action();
    }

    void OnTriggerStay2D(Collider2D col){
        if(!col.CompareTag("Player")) return;
        action();
    }
    
    void OnTriggerExit2D(Collider2D col){
        if (col.CompareTag("Player")){
            Message.text = ("");
        }
    }

    public virtual void action(){} //abstract
}
