using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private Rigidbody2D rb;

    /* Public vars */
    public int damage = 40;
    public GameObject bulletAnim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5); 
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        // TODO: mudar para tags
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
                animate();
                Destroy(gameObject);
        }

        if(hitInfo.attachedRigidbody && hitInfo.attachedRigidbody.name=="Water"){
            animate2();
            Destroy(gameObject);
            Destroy(hitInfo.gameObject, 0.3f);
        }

        else if(hitInfo.attachedRigidbody && hitInfo.attachedRigidbody.tag=="Explode"){
            animate();
            Destroy(gameObject);
        }
    }

    private void animate(){
        GameObject x = Instantiate(bulletAnim, transform.position, transform.rotation);
        Destroy(x, 0.6f);
    }

    private void animate2(){
        GameObject x = Instantiate(bulletAnim, transform.position, transform.rotation);
        x.transform.localScale = new Vector3(25f, 25f, 0f);
        Destroy(x, 0.5f);
    }
}
