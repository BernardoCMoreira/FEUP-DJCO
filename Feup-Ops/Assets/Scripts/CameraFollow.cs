using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform target;
    public float dampTime = 0.7f;
    private Vector3 camPosition;
    private Vector3 velocity = Vector3.zero;

    void Update(){
        if(!target){
            return;
        }

        if(target.position.y < -10f){
             camPosition = new Vector3(-2f, -18f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }

        else if(target.position.x > -18f && target.position.x < 18f) { /*1*/
            camPosition = new Vector3(1f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 18f && target.position.x < 56f) { //2
            camPosition = new Vector3(38f,  -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 56f && target.position.x < 92f) { // 3
            camPosition = new Vector3(78f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 92f) { // 4
            camPosition = new Vector3(114f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        
    }

}
