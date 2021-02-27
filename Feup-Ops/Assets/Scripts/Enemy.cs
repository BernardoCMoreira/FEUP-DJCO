using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;

    private float speed = 0.25f;
    private Transform target;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update(){
        if(health <= 0 ){
            anim.SetBool("isDying", true);
            Die();
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
    }

   void OnCollisionEnter2D(Collision2D col)
    {   
        if(col.gameObject.name == "Player"){
            Destroy(col.gameObject);
        } 
    }

    void Die()
    {   
        Destroy(gameObject, 2);
    }
}
