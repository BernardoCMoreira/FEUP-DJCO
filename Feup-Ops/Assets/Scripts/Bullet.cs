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
        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.tag) == "Player") ){
            return;
        }           

        if(hitInfo.attachedRigidbody && 
            ((rb.tag == "AmmoClock" && hitInfo.attachedRigidbody.tag == "DiscoEnemy") ||
             (rb.tag == "AmmoCoffee" && hitInfo.attachedRigidbody.tag == "BeerEnemy")) ){
                Enemy enemy  = hitInfo.GetComponent<Enemy>();
                if(enemy!= null){
                    enemy.TakeDamage(damage);
                }
                animate();
                Destroy(gameObject);
        }

//switch para a attachedrigid body
        if(hitInfo.attachedRigidbody && hitInfo.attachedRigidbody.tag == "BossEnemy"){
            Boss boss = hitInfo.GetComponent<Boss>();
            if(boss != null) {
                boss.TakeDamage(damage);
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

    private void animate(){ //passar bool para local scale
        GameObject x = Instantiate(bulletAnim, transform.position, transform.rotation);
        Destroy(x, 0.6f);
    }

    private void animate2(){
        GameObject x = Instantiate(bulletAnim, transform.position, transform.rotation);
        x.transform.localScale = new Vector3(25f, 25f, 0f);
        Destroy(x, 0.5f);
    }
}
