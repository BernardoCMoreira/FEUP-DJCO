
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] int health = 200;
    [SerializeField] GameObject target; //player
    [SerializeField] float MinDist;

    float timeBtwSpawn;
    [SerializeField] float startTimeSpawn = 4f;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] HealthBar healthBar;

    Animator anim;


    void Start()
    {
        timeBtwSpawn = startTimeSpawn;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        if(health <= 0 ){
            Die();
        }

        if(Player.isFrozen || !target){
            return;
        }

        if((Vector2.Distance(transform.position, target.transform.position) <= MinDist) && health > 0) {
            generateEnemies();
        }
    }

    void generateEnemies(){
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);


        if (timeBtwSpawn <=0){
            SoundManager.playSound("bossAtack", 0.65f);
            anim.SetTrigger("isAttacking");
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            timeBtwSpawn = startTimeSpawn;
            anim.SetBool("isQuiet", true);
        } else{
            timeBtwSpawn -=Time.deltaTime;
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

