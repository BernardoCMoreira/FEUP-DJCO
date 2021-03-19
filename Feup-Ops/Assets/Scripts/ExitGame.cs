using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : Door
{
    public override void action(){
        Message.text = ("PRESS [O] TO OPEN");
        
        if(Input.GetKeyDown(KeyCode.O)){
            GameController gameController = player.GetComponent<GameController>();
                if(gameController)
                    gameController.endGame();
        }
    }
}
