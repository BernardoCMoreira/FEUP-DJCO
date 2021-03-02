using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private Animator anim;

    private Transform target;

    public GameObject projectile;
    private float startTimeBtwShots = 2.5f;
    private float timeBtwShots;

    /* Public vars */
    public float speed = 0.25f;
    public int health = 100;
    public int MinDist = 5;

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

        if((Vector2.Distance(transform.position, target.position) <= MinDist) && health > 0) {
            anim.SetBool("isWalking", true);
            attackPlayer();
        }
        else {
            anim.SetBool("isWalking", false);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
    }

   void OnCollisionEnter2D(Collision2D col)
    {           
        if(col.gameObject.name == "Player"){ 
            PlayerBehavior pb = col.gameObject.GetComponent<PlayerBehavior>();
            if(pb!=null) {
                pb.Die();
            }
        } 
    }

    void Die()
    {   
        Destroy(gameObject, 0.5f);
    }

    void attackPlayer(){
        //lookAtPlayer(); >> LookAt(..) not working
        //lookAtPlayer();

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

        if (timeBtwShots <=0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else{
            timeBtwShots -=Time.deltaTime;
        }
        
    }

    void lookAtPlayer(){
        if(target.position.x < transform.position.x){
            transform.Rotate(0f, 180f, 0f);
        }
    }

}
