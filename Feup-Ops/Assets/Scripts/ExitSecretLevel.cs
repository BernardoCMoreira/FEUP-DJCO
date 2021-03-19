using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSecretLevel : Door
{
    [SerializeField] Boss boss;
    public override void action(){
        if (boss){
            Message.text = ("This door is locked...");
        }
        else {
            Message.text = ("PRESS [O] TO OPEN");

            if(Input.GetKeyDown(KeyCode.O)){
                player.exitSecretLevel();
            }
        }
    }
}
