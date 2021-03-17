using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [SerializeField] Transform target;
    float dampTime = 0.4f;
    Vector3 camPosition;
    Vector3 velocity = Vector3.zero;

    void Update(){
        if(!target){
            return;
        }

        if(target.position.y < -10f){
             camPosition = new Vector3(-1f, -33f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime/1.75f);
        }
        else if(target.position.x > -18f && target.position.x < 18f) { 
            camPosition = new Vector3(0.5f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 18f && target.position.x < 56f) { 
            camPosition = new Vector3(38f,  -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 56f && target.position.x < 92f) { 
            camPosition = new Vector3(78f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x >= 92f) { 
            camPosition = new Vector3(114f, -2f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        
    }

}
