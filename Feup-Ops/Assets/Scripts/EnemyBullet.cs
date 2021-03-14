using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Transform target;

    /* Public vars */
    public float speed = 5f;
    public int damage = 40;


    void Start()
    {       
            rb = gameObject.GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            if(rb.transform.position.x <= target.position.x){
                rb.velocity = transform.right * speed;
            } else {
                rb.velocity = -transform.right * speed;
            }

            Destroy(gameObject, 4);
    }


    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "DiscoEnemy") 
            ||  hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "BeerEnemy") ){
            return;
        }           
       
        if(hitInfo.attachedRigidbody && (hitInfo.attachedRigidbody.name == "Player")){
            Player pb = hitInfo.GetComponent<Player>();
            if(pb!= null){
                pb.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if(hitInfo.attachedRigidbody && hitInfo.attachedRigidbody.tag=="Explode"){
            Destroy(gameObject);
        }
    }


}
