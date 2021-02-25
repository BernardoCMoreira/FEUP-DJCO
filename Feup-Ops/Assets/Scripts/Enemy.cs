using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    //public GameObject deathEffect;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update(){
        if(health <= 0 ){
            anim.SetBool("isDying", true);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage; 
    }
    void Die()
    {   
        Destroy(gameObject, 2);
    }
}
