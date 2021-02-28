using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    public float speed = 5f;
    private Rigidbody2D rb;
     private Transform target;
    // Start is called before the first frame update
    void Start()
    {       
            rb = gameObject.GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            if(rb.transform.position.x <= target.position.x){
                rb.velocity = transform.right * speed;
            } else {
                rb.velocity = -transform.right * speed;
            }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "DiscoEnemy") 
            ||  hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "BeerEnemy") ){
            return;
        }           

        if(hitInfo.attachedRigidbody && (hitInfo.attachedRigidbody.name == "Player")){
            Debug.Log("Player Got Shot");    
            Destroy(gameObject);
        }
    }


}
