using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public GameObject target;
    public float timeBtwShots = 2;

    Vector2 lookDirection;
    float lookAngle;

    private Player player;
    
    void Start(){
        player = (Player) target.GetComponent(typeof(Player));

    }

    void Update()
    {   
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(target.transform.position.x, target.transform.position.y);
        
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)  * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
       

        if (Input.GetMouseButtonDown(0))
        {
            player.shoot(lookDirection.x, lookDirection.y);

            GameObject bulletClone = Instantiate(bullet1);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
        if (Input.GetMouseButtonDown(1)){
            player.shoot(lookDirection.x, lookDirection.y);

            GameObject bulletClone = Instantiate(bullet2);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }

}