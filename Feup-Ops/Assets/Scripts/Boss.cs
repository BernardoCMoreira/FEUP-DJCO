
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public float health = 200;
    public GameObject target; //player
    public float MinDist;

    private float timeBtwSpawn;
    public float startTimeSpawn = 4f;

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawn = startTimeSpawn;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 ){
            //anim.SetBool("isDying", true);
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
            SoundManager.playSound("bossAtack", 0.45f);
            anim.SetTrigger("isAttacking");
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            timeBtwSpawn = startTimeSpawn;
            anim.SetBool("isQuiet", true);
        } else{
            timeBtwSpawn -=Time.deltaTime;
        }
    }

    public void TakeDamage(float damage){
        health -= damage; 
    }

    
    void Die()
    {   
        Destroy(gameObject, 0.5f);
    }
}

