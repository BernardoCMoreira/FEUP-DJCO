using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    Rigidbody2D rb;
    [SerializeField] int damage = 40;
    [SerializeField] GameObject bulletAnim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5); 
    }

    void OnTriggerEnter2D(Collider2D hitInfo){       
        if(hitInfo.attachedRigidbody && ((hitInfo.attachedRigidbody.tag) == "Player") ){
            return;
        }           

        if(hitInfo.attachedRigidbody){
            if((rb.tag == "AmmoClock" && hitInfo.attachedRigidbody.tag == "DiscoEnemy") ||
             (rb.tag == "AmmoCoffee" && hitInfo.attachedRigidbody.tag == "BeerEnemy")) {
                Enemy enemy  = hitInfo.GetComponent<Enemy>();
                if(enemy!= null){
                    enemy.TakeDamage(damage);
                }
                animateAndDestroy(false);
            }

            else if(hitInfo.attachedRigidbody.tag == "BossEnemy"){
                Boss boss = hitInfo.GetComponent<Boss>();
                if(boss != null) {
                    boss.TakeDamage(damage);
                }
                animateAndDestroy(false);
            }

            else if(hitInfo.attachedRigidbody.name=="Water"){
                animateAndDestroy(true);
                Destroy(hitInfo.gameObject, 0.3f);
            }

            else if(hitInfo.attachedRigidbody.tag=="Explode"){
                animateAndDestroy(false);
            }
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

    private void animateAndDestroy(bool isBigExplosion){
        if(isBigExplosion)
            animate2();
        else 
            animate();

        Destroy(gameObject);
    }
}
