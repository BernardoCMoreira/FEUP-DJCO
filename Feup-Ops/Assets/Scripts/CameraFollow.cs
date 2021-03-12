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

        if(target.position.x > 16f && target.position.y >= -6f) { /*top right*/
            camPosition = new Vector3(34f, 0, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x <= 16f && target.position.y >= -6f) { /* top left */
             camPosition = new Vector3(0f,  0f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x <= 16f && target.position.y < -6f) { /* bottom left */
             camPosition = new Vector3(0f, -15.3f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
        else if(target.position.x > 16f && target.position.y <-6f) { /*bottom right*/
             camPosition = new Vector3(34f, -15.3f, -10f); 
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, camPosition, ref velocity, dampTime);
        }
    }


}
