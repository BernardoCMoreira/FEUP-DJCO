using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;

    private float speed = 0.25f;
    private Transform target;

    public GameObject projectile;
    public float startTimeBtwShots;
    private float timeBtwShots;

    void Start()
    {   
        timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update(){
        if(health <= 0 ){
            anim.SetBool("isDying", true);
            Die();
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

        if (timeBtwShots <=0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -=Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
    }

   void OnCollisionEnter2D(Collision2D col)
    {   
        if(col.gameObject.name == "Player"){

            // Uncoment line below in order to destroy player when he dies
            //Destroy(col.gameObject);


            // will leave a debug log to remember me to uncoment line above
            Debug.Log("Player died");
        } 
    }

    void Die()
    {   
        Destroy(gameObject, 2);
    }
}
