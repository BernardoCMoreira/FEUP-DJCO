﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    Animator anim;
    Transform target;
    float timeBtwShots;
    bool facingRight;

    [SerializeField] float speed;
    [SerializeField] int health;
    [SerializeField] int MinDist;
    [SerializeField] GameObject projectile;
    [SerializeField] float startTimeBtwShots;
    [SerializeField] HealthBar healthBar;
    
    void Start()
    {   
        speed = 0.25f;
        health = 100;
        startTimeBtwShots = 1f;
        facingRight = true;
        timeBtwShots = startTimeBtwShots;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthBar.SetMaxHealth(health);
    }
    
    void Update(){
        if(health <= 0 ){
            anim.SetBool("isDying", true);
            Die();
        }
        
        if(Player.isFrozen || !target){
            return;
        }

        if(transform.position.x < target.position.x && !facingRight)
            Flip();
        else if(transform.position.x > target.position.x  && facingRight)
            Flip();
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
        healthBar.SetHealth(health);
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
        SoundManager.playSound("enemyDeath", 0.45f);
        Destroy(gameObject, 0.5f);
    }

    void attackPlayer(){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

        if (timeBtwShots <=0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        } else{
            timeBtwShots -=Time.deltaTime;
        }   
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
