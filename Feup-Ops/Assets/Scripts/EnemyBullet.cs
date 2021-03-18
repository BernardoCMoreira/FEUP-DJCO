using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    Rigidbody2D rb;
    Transform target;

    /* Public vars */
    [SerializeField] float speed = 5f;
    [SerializeField] int damage = 40;

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
        if(hitInfo.attachedRigidbody){
            if(hitInfo.attachedRigidbody.tag == "DiscoEnemy" || hitInfo.attachedRigidbody.tag == "BeerEnemy" ){
                return;
            }           
            if(hitInfo.attachedRigidbody.tag == "Player"){
                Player pb = hitInfo.GetComponent<Player>();
                if(pb!= null){
                    pb.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            else if(hitInfo.attachedRigidbody.tag=="Explode"){
                Destroy(gameObject);
            }
        }
    }


}
