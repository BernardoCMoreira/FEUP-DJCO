using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody2D rb;

    
    /* Public vars */
    public int damage = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5); 
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.name) == "Player") ){
            return;
        }           

        if(hitInfo.attachedRigidbody && 
                ((rb.name == "AmmoClock(Clone)" && hitInfo.attachedRigidbody.name == "DiscoEnemy") ||
                 (rb.name == "AmmoCoffee(Clone)" && hitInfo.attachedRigidbody.name == "BeerEnemy"))){

                    Enemy enemy  = hitInfo.GetComponent<Enemy>();
                    if(enemy!= null){
                        enemy.TakeDamage(damage);
                    }

                    Destroy(gameObject);
        }
    }
}
