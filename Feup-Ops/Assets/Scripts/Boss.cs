
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] int health = 200;
    [SerializeField] GameObject target; //player
    [SerializeField] float MinDist = 15f;

    float timeBtwSpawn;
    [SerializeField] float spawnRate = 4f;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] HealthBar healthBar;

    Animator anim;
    float nextSpawn;


    void Start()
    {   
        nextSpawn = 0.0f;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        if(health <= 0 ){
            Die();
        }

        if(!target){
            return;
        }

        if((Vector2.Distance(transform.position, target.transform.position) <= MinDist) && health > 0) {
            generateEnemies();
        }
    }

    void generateEnemies(){
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        

        if (Time.time > nextSpawn){
            SoundManager.playSound("bossAtack", 0.65f);
            anim.SetTrigger("isAttacking");
            float x = spawnPoints[randSpawnPoint].position.x;
            float y = spawnPoints[randSpawnPoint].position.y;
            Instantiate(enemyPrefabs[randEnemy], new Vector3(x,y,0), transform.rotation);
            anim.SetBool("isQuiet", true);
            nextSpawn = Time.time + spawnRate; 
        }

     
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthBar.SetHealth(health);
    }

    
    void Die()
    {   
        Destroy(gameObject, 0.5f);
    }
}

