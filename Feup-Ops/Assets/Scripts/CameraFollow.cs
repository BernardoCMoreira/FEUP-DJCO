using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform target;
    public float dampTime = 0.4f;
    private Vector3 camPosition;
    private Vector3 velocity = Vector3.zero;

    void Update(){
        //Debug.Log(player.position.x);
        //camPosition = new Vector3(player.position.x, player.position.y, -10f);

        Debug.Log(target.position.y);


        if(target.position.x > 16f && target.position.y >= -6f) {
            camPosition = new Vector3(30f, gameObject.transform.position.y, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x <= 16f && target.position.y >= -6f) {
             camPosition = new Vector3(1f, gameObject.transform.position.y, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x <= 16f && target.position.y < -6f) {
             camPosition = new Vector3(1f, -13f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x > 16f && target.position.y <-6f) {
             camPosition = new Vector3(30f, -13f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
    }


}
