using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    Animator anim;
    Transform target;
    float nextFire;
    bool facingRight;

    [SerializeField] float speed = 0.25f;
    [SerializeField] int health = 100;
    [SerializeField] int MinDist = 8;
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate = 1f;
    [SerializeField] HealthBar healthBar;
    
    [SerializeField] Animator FlameAnim;
    
    void Start()
    {   
        facingRight = true;
        nextFire = 0.0f;
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
            if(!FlameAnim.GetCurrentAnimatorStateInfo(0).IsName("BlueFlame")){
                FlameAnim.SetBool("isFreeze", true);
            }
            return;
        }

        if(!Player.isFrozen && FlameAnim.GetCurrentAnimatorStateInfo(0).IsName("BlueFlame")){
            FlameAnim.SetBool("isFreeze", false);
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
        if (Time.time > nextFire){
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate; 
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
