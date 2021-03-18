using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] GameObject target;
    [SerializeField] float fireRate = 0.75f;
    
    float nextFire;
    Vector2 lookDirection;
    float lookAngle;
    Player player;
    
    void Start(){
        nextFire = 0.0f;
        player = (Player) target.GetComponent(typeof(Player));
    }

    void Update()
    {   
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(target.transform.position.x, target.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)  * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if( Time.time > nextFire) {
            if (Input.GetMouseButtonDown(0))
            {
                instatiateBullet(1);
                nextFire = Time.time + fireRate;
            }
            else if (Input.GetMouseButtonDown(1)){
                instatiateBullet(2);
                nextFire = Time.time + fireRate;
            }
        }
    }

    void instatiateBullet(int type){
        SoundManager.playSound("playerShoot", 0.6f);

        player.shoot(lookDirection.x, lookDirection.y);

        GameObject bulletClone;

        if(type == 1) 
            bulletClone = Instantiate(bullet1);
        else
            bulletClone = Instantiate(bullet2);

        bulletClone.transform.position = firePoint.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }

}