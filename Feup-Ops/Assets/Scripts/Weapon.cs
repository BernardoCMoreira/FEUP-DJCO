using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public GameObject player;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {   
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(player.transform.position.x, player.transform.position.y);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)  * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            /*if(lookAngle > 90f && lookAngle < 180f) {
                PlayerBehavior playerBehavior = (PlayerBehavior) player.GetComponent(typeof(PlayerBehavior));
            }*/

            GameObject bulletClone = Instantiate(bullet1);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
        if (Input.GetMouseButtonDown(1)){
            GameObject bulletClone = Instantiate(bullet2);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);


            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}