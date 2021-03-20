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
    [SerializeField] int bulletDurationTime = 5;
    [SerializeField] GameObject bulletAnim;

    private Vector3 direction;

    void Start()
    {   
        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        direction = (target.position - transform.position).normalized ;

        Destroy(gameObject, bulletDurationTime);
    }

    void Update(){
         transform.position += direction * speed * Time.deltaTime;
         
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
                GameObject x = Instantiate(bulletAnim, transform.position, transform.rotation);
                Destroy(x, 0.6f);
                Destroy(gameObject);
            }
        }
    }


}
