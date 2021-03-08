﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private Animator anim;

    private Transform target;

    private float timeBtwShots;


    /* Public vars */
    public float speed = 0.25f;
    public int health = 100;
    public int MinDist = 5;
    public GameObject projectile;
    public float startTimeBtwShots = 1f;


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
        
        if(Player.isFrozen){
            return;
        }

        if(target == null) {
            Debug.Log("Player lost!");
            //TODO: redirecionar menu
        }
        else {
            if((Vector2.Distance(transform.position, target.position) <= MinDist) && health > 0) {
                anim.SetBool("isWalking", true);
                attackPlayer();
            }
            else {
                anim.SetBool("isWalking", false);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
    }

   void OnCollisionEnter2D(Collision2D col)
    {           
        if(col.gameObject.tag == "Player"){ 
            Player pb = col.gameObject.GetComponent<Player>();
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
